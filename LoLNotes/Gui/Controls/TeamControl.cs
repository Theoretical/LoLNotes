﻿/*
copyright (C) 2011 by high828@gmail.com

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
 */


using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using LoLNotes.Storage;

namespace LoLNotes.Gui.Controls
{
    public partial class TeamControl : UserControl
    {
        /// <summary>
        /// This control is used for sizing and such.
        /// </summary>
        protected PlayerControl BasePlayer;

        const int PlayersStartY = 36;
        const int PlayersYSpacing = 10;

        protected int teamsize;
        public int TeamSize
        {
            get
            {
                return teamsize;
            }
            set
            {
                teamsize = value;
                Width = BasePlayer.Width;
                Height = PlayersStartY + value * (BasePlayer.Height + PlayersYSpacing);

                foreach (PlayerControl p in Players)
                    p.Dispose();
                Players.Clear();

                for (int i = 0; i < value; i++)
                {
                    var control = new PlayerControl();
                    control.Location = new Point(0, PlayersStartY + (BasePlayer.Height + PlayersYSpacing) * i);
                    control.ContextMenuStrip = PlayerContextMenuStrip;
                    control.Visible = false;
                    Players.Add(control);
                    Controls.Add(control);
                }

            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public GameStorage Storage { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<PlayerControl> Players { get; set; }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        public override string Text
        {
            get
            {
                return NameLabel.Text;
            }
            set
            {
                NameLabel.Text = value;
            }
        }


        protected ContextMenuStrip playercontextmenustrip;
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        public ContextMenuStrip PlayerContextMenuStrip
        {
            get
            {
                return playercontextmenustrip;
            }
            set
            {
                playercontextmenustrip = value;
                foreach (var plr in Players)
                    plr.ContextMenuStrip = value;
            }
        }


        public TeamControl()
        {
            Players = new List<PlayerControl>();
            BasePlayer = new PlayerControl();
            TeamSize = 5;
            InitializeComponent();
        }

        /// <summary>
        /// Sets the data for the player at idx.
        /// </summary>
        /// <param name="idx">Index of the player</param>
        /// <param name="entry">Data of the player</param>
        public void SetData(int idx, PlayerEntry entry)
        {

        }
    }
}
