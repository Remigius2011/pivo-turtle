using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PivoTurtle
{
    public partial class TemplateForm : Form
    {
        private string template;
        private List<PivotalStory> stories;
        private string originalMessage;
        private StoryMessageTemplate messageTemplate = new StoryMessageTemplate();

        public string Template
        {
            get { return template; }
            set { template = value; }
        }

        public List<PivotalStory> Stories
        {
            get { return stories; }
            set { stories = value; }
        }

        public string OriginalMessage
        {
            get { return originalMessage; }
            set { originalMessage = value; }
        }

        public static bool EditTemplate(ref string template, List<PivotalStory> stories, string originalMessage)
        {
            TemplateForm form = new TemplateForm();
            form.Template = template;
            form.Stories = stories;
            form.OriginalMessage = originalMessage;
            if (form.ShowDialog() == DialogResult.OK)
            {
                template = form.Template;
                return true;
            }
            return false;
        }

        public TemplateForm()
        {
            InitializeComponent();
        }

        private void TemplateForm_Load(object sender, EventArgs e)
        {
            textBoxTemplate.Text = template;
        }

        private void textBoxTemplate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                messageTemplate.Template = textBoxTemplate.Text;
                textBoxPreview.Text = messageTemplate.Evaluate(stories, originalMessage);
                labelOkFail.ImageIndex = 0;
                buttonOk.Enabled = true;
            }
            catch (Exception x)
            {
                labelOkFail.ImageIndex = 1;
                textBoxPreview.Text = "";
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            template = textBoxTemplate.Text;
            buttonOk.Enabled = false;
        }
    }
}
