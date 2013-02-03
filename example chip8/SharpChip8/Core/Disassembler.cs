using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpChip8.Core
{
    public class Disassembler
    {
        private Chip8 _chip8;

        private string asmWithLineNumber;
        private string asmWithoutLineNumber;

        public string AsmWithLineNumber
        {
            get
            {
                if (asmWithLineNumber == String.Empty)
                    asmWithLineNumber = GetStringProgramAssembly(true);
                return asmWithLineNumber;
            }
        }

        public string AsmWithoutLineNumber
        {
            get
            {
                if (asmWithoutLineNumber == String.Empty)
                    asmWithoutLineNumber = GetStringProgramAssembly(false);
                return asmWithoutLineNumber;
            }
        }

        public Disassembler(Chip8 chip8)
        {
            _chip8 = chip8;
            asmWithoutLineNumber = String.Empty;
            asmWithLineNumber = String.Empty;
        }

        public string GetStringProgramAssembly(bool withLine)
        {
            List<string> asm = GetProgramAssembly();

            for (int i = 0; i < asm.Count; i++)
            {
                string lineNumber = i.ToString();
                if (i < 10)
                    lineNumber = String.Format("000{0}: ", i);
                else if (i < 100)
                    lineNumber = String.Format("00{0}: ", i);
                else if (i < 1000)
                    lineNumber = String.Format("0{0}: ", i);
                asmWithLineNumber += lineNumber + asm[i] + "\r\n";
                asmWithoutLineNumber += asm[i] + "\r\n";
            }

            if (withLine)
                return asmWithLineNumber;
            else
                return asmWithoutLineNumber;
        }

        public List<string> GetProgramAssembly()
        {
            byte[] memory = _chip8.Cpu.Memory;
            List<string> asm = new List<string>();

            for (int i = Memory.StartAddress; i < Memory.MemorySize - 1; i++)
            {
                
                ushort opcode = (ushort)((memory[i] << 8) + memory[i + 1]);
                ushort action = _chip8.Cpu.GetAction(opcode);

                string VX = String.Format("{0:X}", (opcode & 0x0F00) >> 8);
                string VY = String.Format("{0:X}",(opcode & 0x00F0) >> 4);
                string Constant = String.Format("{0:X}", opcode & 0x000F);
                string NNN = String.Format("{0:X}", VX + VY + Constant);
                string NN = String.Format("{0:X}", VX + VY);

                switch (action)
                {
                    case 0:         // 0NNN
                        break;
                    case 1:         // 00E0 : Effacer l'écran
                        asm.Add("CLS");
                        break;
                    case 2:         // 00EE : Retourne à partir d'un sous programme
                        asm.Add("RTS");
                        break;
                    case 3:         // 1NNN : Effectue un saut à l'adresse NNN
                        asm.Add("JMP " + NNN);
                        break;
                    case 4:         // 2NNN : Execute un sous programme à l'adresse NNN
                        asm.Add("JSR " + NNN);
                        break;
                    case 5:         // 3XNN : Saute l'instruction suivante si VX == NN
                        asm.Add(String.Format("SKEQ V{0}, {1}", VX, NN));
                        break;  
                    case 6:         // 4XNN : Saute l'instruction suivante si VX != NN
                        asm.Add(String.Format("SKNE V{0}, {1}", VX, NN));
                        break;
                    case 7:         // 5XY0 : Saute à l'instruction suivante si VX == VY
                        asm.Add(String.Format("SKEQ V{0}, {1}", VX, VY));
                        break;
                    case 8:         // 6XNN : Définie VX à NN
                        asm.Add(String.Format("MOV V{0}, {1}", VX, NN));
                        break;
                    case 9:         // 7XNN : Ajoute NN à VX
                        asm.Add(String.Format("ADD V{0}, {1}", VX, NN));
                        break;
                    case 10:        // 8XY0 : Définie VX à la valeur VY
                        asm.Add(String.Format("MOV V{0}, V{1}", VX, VY));
                        break;
                    case 11:        // 8XY1 :Définie VX à VX OR VY
                        asm.Add(String.Format("OR V{0}, V{1}", VX, VY));
                        break;
                    case 12:        // 8XY2 : Définie VX à VX AND VY
                        asm.Add(String.Format("AND V{0}, V{1}", VX, VY));
                        break;
                    case 13:        // 8XY3 : Définie VX à VX XOR VY
                        asm.Add(String.Format("XOR V{0}, V{1}", VX, VY));
                        break;
                    case 14:        // 8XY4 : VY += VX, si le résultat est > 0xff VF = 0x1 sinon VF = 0x0
                        asm.Add(String.Format("ADD V{0}, V{1}", VX, VY));
                        break;
                    case 15:        // 8XY5 : VY = VY - VX, si le resultat est négatif VF = 0x1 sinon VF = 0x0
                        asm.Add(String.Format("SUB V{0}, V{1}", VX, VY));
                        break;
                    case 16:        // 8XY6 : Décale VX à droite de 1 bit, VF = valeur du bit de poids faible de VX avant décalage
                        asm.Add(String.Format("SHR V{0}, V{1}", VX, VY));
                        break;
                    case 17:        // 8XY7 : VX = VY - VX, si le résultat est < 0 VF = 0x1 sinon VF = 0x0
                        asm.Add(String.Format("RSB V{0}, V{1}", VX, VY));
                        break;
                    case 18:        // 8XYE : Décale VX à gauche de 1 bit, VF = valeur du bit de poids fort de VX avant décalage
                        asm.Add(String.Format("SHL V{0}", VX));
                        break;
                    case 19:        // 9XY0 : Saute l'instruction suivante si VX et VY ne sont pas égaux
                        asm.Add(String.Format("SKNE V{0}, V{1}", VX, VY));
                        break;
                    case 20:        // ANNN : Affecte NNN à I
                        asm.Add(String.Format("MVI {0}", NNN));
                        break;      
                    case 21:        // BNNN : Passe à l'adresse NNN + V0
                        asm.Add(String.Format("JMI {0}", NNN));
                        break;
                    case 22:        // CXNN : Définit VX à un nombre aléatoire < NN
                        asm.Add(String.Format("RND {0}, {1}", VX, NNN));
                        break;
                    case 23:        // DXYN : Dessine un sprite à l'écran
                        asm.Add(String.Format("DRW V{0}, V{1}, {2}", VX, VY, Constant));    
                        break;
                    case 24:        // EX9E : Saute l'instruction suivante si la touche représentée par VX == 0x1
                        asm.Add(String.Format("SKPR V{0}", VX));
                        break;
                    case 25:        // EXA1 : Saute l'instruction suivante si la touche représentée par VX == 0x0
                        asm.Add(String.Format("SKUP V{0}", VX));
                        break;
                    case 26:        // FX07 : Définie VX = Tempo Jeu
                        asm.Add(String.Format("GDELAY V{0}", VX));
                        break;
                    case 27:        // FX0A : Attend l'appuie sur une touche et le retour est stocké dans VX
                        asm.Add(String.Format("KEY V{0}", VX));
                        break;
                    case 28:        // FX15 : Définie la tempo du jeu à VX
                        asm.Add(String.Format("SDELAY V{0}", VX));
                        break;
                    case 29:        // FX18 : Définie la tempo du son à VX
                        asm.Add(String.Format("SSOUND V{0}", VX));
                        break;
                    case 30:        // FX1E : I = VX + I, VF = 1 si il y a un depassement de mémoire sinon VF = 0
                        asm.Add(String.Format("ADI V{0}", VX));
                        break;
                    case 31:        // FX29 : Défnit I à l'emplacement du caractère sotcké dans VX
                        asm.Add(String.Format("FONT V{0}", VX));
                        break;
                    case 32:        // FX33 :  Stocke dans la mémoire le code décimal représentant VX
                        asm.Add(String.Format("BCD V{0}", VX));
                        break;
                    case 33:        // FX55 : Stock le contenu des registres V0 jusqu'à VX en mémoire à partir de l'adresse I
                        asm.Add(String.Format("STR V0, V{0}", VX));
                        break;
                    case 34:        // FX65 : Rempli les registres V0 à VX avec le contenu de la mémoire à partir de I
                        asm.Add(String.Format("LDR V0, V{0}", VX));
                        break;
                    default:
                        break;
                }
            }
            return asm;
        }
    }
}
