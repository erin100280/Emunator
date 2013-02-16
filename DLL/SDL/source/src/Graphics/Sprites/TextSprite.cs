#region LICENSE
/*
 * $RCSfile$
 * Copyright (C) 2004 D. R. E. Moonfire (d.moonfire@mfgames.com)
 *
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 * 
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 */
#endregion LICENSE

using System;
using System.Drawing;
using System.Globalization;

using SdlDotNet;
using SdlDotNet.Core;
using SdlDotNet.Graphics;

namespace SdlDotNet.Graphics.Sprites
{
    /// <summary>
    /// Implements a basic font that is given a font and a string and
    /// generates an appropriate surface from that font.
    /// </summary>
    public class TextSprite : Sprite
    {
        #region Constructors
        /// <summary>
        /// Creates a new TextSprite given the font.
        /// </summary>
        /// <param name="font">The font to use when rendering.</param>
        public TextSprite(SdlDotNet.Graphics.Font font)
            : this(" ", font)
        {
        }

        /// <summary>
        /// Creates a new TextSprite with given the text and font.
        /// </summary>
        /// <param name="textItem">Text to display</param>
        /// <param name="font">The font to use when rendering.</param>
        public TextSprite(
            string textItem,
            SdlDotNet.Graphics.Font font)
            : this(textItem, font, Color.White)
        {
        }

        /// <summary>
        /// Creates a new TextSprite given the text, font and color.
        /// </summary>
        /// <param name="textItem">Text to display</param>
        /// <param name="font">The font to use when rendering.</param>
        /// <param name="color">color of Text</param>
        public TextSprite(
            string textItem,
            SdlDotNet.Graphics.Font font,
            Color color)
            : this(textItem, font, color, true)
        {
        }

        /// <summary>
        /// Creates a new TextSprite given the text, font, color and anti-aliasing flag.
        /// </summary>
        /// <param name="textItem">Text to display</param>
        /// <param name="font">The font to use when rendering.</param>
        /// <param name="color">Color of Text</param>
        /// <param name="antiAlias">A flag determining if it's to 
        /// use anti-aliasing when rendering. Defaults to true.</param>
        public TextSprite(
            string textItem,
            SdlDotNet.Graphics.Font font,
            Color color, bool antiAlias)
            : this(textItem, font, color, antiAlias, new Point(0, 0))
        {
        }
        /// <summary>
        /// Creates a new TextSprite given the text, font, color and background color.
        /// </summary>
        /// <param name="textItem">Text to display</param>
        /// <param name="font">The font to use when rendering.</param>
        /// <param name="textColor">Text Color</param>
        /// <param name="backgroundColor">Background color</param>
        public TextSprite(
            string textItem,
            SdlDotNet.Graphics.Font font,
            Color textColor,
            Color backgroundColor)
            : this(textItem, font, textColor)
        {
            this.backgroundColor = backgroundColor;
        }

        /// <summary>
        /// Creates a new TextSprite given the text, font and position.
        /// </summary>
        /// <param name="textItem"></param>
        /// <param name="font">The font to use when rendering.</param>
        /// <param name="position"></param>
        public TextSprite(
            string textItem,
            SdlDotNet.Graphics.Font font,
            Point position)
            : this(textItem, font, true, position)
        {
        }

        /// <summary>
        /// Creates a new TextSprite given the text, font, anti-aliasing flag and position.
        /// </summary>
        /// <param name="textItem">Text to display</param>
        /// <param name="font">The font to use when rendering.</param>
        /// <param name="antiAlias">A flag determining if it's to use 
        /// anti-aliasing when rendering. Defaults to true.</param>
        /// <param name="position">Position of sprite</param>
        public TextSprite(
            string textItem,
            SdlDotNet.Graphics.Font font,
            bool antiAlias,
            Point position)
            : this(textItem, font, Color.White, antiAlias, position)
        {
        }

        /// <summary>
        /// Creates a new TextSprite given the text, font, color and position.
        /// </summary>
        /// <param name="textItem">Text to display</param>
        /// <param name="font">The font to use when rendering.</param>
        /// <param name="color">Color of Text</param>
        /// <param name="position">Position of Sprite</param>
        public TextSprite(
            string textItem,
            SdlDotNet.Graphics.Font font,
            Color color,
            Point position)
            : this(textItem, font, color, true, position)
        {
        }

        /// <summary>
        /// Creates a new TextSprite given the text, font, color, anti-aliasing flag and position.
        /// </summary>
        /// <param name="textItem">Text to display</param>
        /// <param name="font">The font to use when rendering.</param>
        /// <param name="color">Color of Text</param>
        /// <param name="antiAlias">A flag determining if it's to use anti-aliasing when rendering. Defaults to true.</param>
        /// <param name="position">Position of Sprite</param>
        public TextSprite(
            string textItem,
            SdlDotNet.Graphics.Font font,
            Color color,
            bool antiAlias,
            Point position)
            : base()
        {
            if (font == null)
            {
                throw new ArgumentNullException("font");
            }
            base.Surface = font.Render(textItem, color);
            this.textItem = textItem;
            this.font = font;
            this.color = color;
            this.antiAlias = antiAlias;
            base.Position = position;
            this.RenderInternal();
        }
        #endregion Constructors

        #region Drawing
        /// <summary>
        /// Renders the font, if both the text and color and font are
        /// set. It stores the render in memory until it is used.
        /// </summary>
        /// <returns>The new renderation surface of the text.</returns>
        private void RenderInternal()
        {
            if (textItem == null)
            {
                textItem = " ";
            }

            // Render it (Solid or Blended)
            try
            {
                base.Surface = font.Render(textItem, color, backgroundColor, antiAlias, textWidth, maxLines);
                //base.Size = new Size(base.Surface.Width, base.Surface.Height);
                base.Transparent = this.transparent;
                base.TransparentColor = this.transparentColor;
            }
            catch (SpriteException e)
            {
                base.Surface = null;
                throw new SdlException(e.ToString());
            }
        }
        #endregion

        #region Font Rendering

        bool transparent;

        /// <summary>
        /// 
        /// </summary>
        public override bool Transparent
        {
            get
            {
                return this.transparent;
            }
            set
            {
                this.transparent = value;
                this.RenderInternal();
            }
        }

        Color transparentColor;

        /// <summary>
        /// 
        /// </summary>
        public override Color TransparentColor
        {
            get
            {
                return this.transparentColor;
            }
            set
            {
                this.transparentColor = value;
                this.RenderInternal();
            }
        }

        private SdlDotNet.Graphics.Font font;
        private bool antiAlias = true;
        int textWidth;
        int maxLines;

        /// <summary>
        /// 
        /// </summary>
        public int TextWidth
        {
            get
            {
                return this.textWidth;
            }
            set
            {
                this.textWidth = value;
                this.RenderInternal();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int MaxLines
        {
            get
            {
                return this.maxLines;
            }
            set
            {
                this.maxLines = value;
                this.RenderInternal();
            }
        }

        /// <summary>
        /// Antialias the text
        /// </summary>
        public bool AntiAlias
        {
            get
            {
                return this.antiAlias;
            }
            set
            {
                this.antiAlias = value;
                this.RenderInternal();
            }
        }

        private string textItem;

        private Color color = Color.White;
        private Color backgroundColor;

        /// <summary>
        /// Gets and sets the color to be used with the text.
        /// </summary>
        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                this.RenderInternal();
            }
        }

        /// <summary>
        /// Gets and sets the background color to be used with the text.
        /// </summary>
        /// <remarks>Defaults as Color.Transparent.</remarks>
        public Color BackgroundColor
        {
            get
            {
                return backgroundColor;
            }
            set
            {
                backgroundColor = value;
                this.RenderInternal();
            }
        }

        /// <summary>
        /// Gets and sets the font to be used with the text.
        /// </summary>
        public SdlDotNet.Graphics.Font Font
        {
            get
            {
                return font;
            }
            set
            {
                if (value == null)
                {
                    throw new SdlException(Events.StringManager.GetString(
                        "NullFont", CultureInfo.CurrentUICulture));
                }
                font = value;
                this.RenderInternal();
            }
        }

        /// <summary>
        /// Gets and sets the text to be rendered.
        /// </summary>
        public string Text
        {
            get
            {
                return textItem;
            }
            set
            {
                textItem = value;
                this.RenderInternal();
            }
        }
        #endregion

        #region Operators
        /// <summary>
        /// Converts the text sprite to a string.
        /// </summary>
        /// <returns>Returns string representation of object</returns>
        public override string ToString()
        {
            return String.Format(CultureInfo.CurrentCulture, "(text \"{0}\",{1})", textItem, base.ToString());
        }
        #endregion

        #region Disposing
        private bool disposed;

        /// <summary>
        /// Destroys the surface object and frees its memory
        /// </summary>
        /// <param name="disposing">If ture, dispose unmanaged resources</param>
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (!this.disposed)
                {
                    if (disposing)
                    {
                        if (this.font != null)
                        {
                            this.font.Dispose();
                            this.font = null;
                        }
                    }
                    this.disposed = true;
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }
        #endregion Disposing
    }
}