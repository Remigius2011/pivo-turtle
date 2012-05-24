﻿/*
 Copyright 2012 Descom Consulting Ltd.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PivoTurtle
{
    public partial class OptionsForm : Form
    {
        public static bool ShowOptions()
        {
            OptionsForm form = new OptionsForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                return true;
            }
            return false;
        }

        public OptionsForm()
        {
            InitializeComponent();
        }

        private void buttonResetToken_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.TokenGuid = "";
            Properties.Settings.Default.TokenId = -1;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
        }
    }
}
