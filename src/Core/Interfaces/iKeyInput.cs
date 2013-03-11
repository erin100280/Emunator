/* User: Erin
 * Date: 2/26/2013
 * Time: 3:56 PM
 */
using System.Windows.Forms;
namespace Emu.Core.Interfaces {
	public interface iInput {
		bool KeyDownInput(KeyEventArgs e);
		bool KeyUpInput(KeyEventArgs e);
	}
}