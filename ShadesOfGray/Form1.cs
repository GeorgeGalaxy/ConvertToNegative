using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShadesOfGray
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // кнопка Открыть
        private void openButton_Click(object sender, EventArgs e)
        {
            // диалог для выбора файла
            OpenFileDialog ofd = new OpenFileDialog();
            // фильтр форматов файлов
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            // если в диалоге была нажата кнопка ОК
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // загружаем изображение
                    pictureBox1.Image = new Bitmap(ofd.FileName);
                }
                catch // в случае ошибки выводим MessageBox
                {
                    MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // кнопка Сохранить
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null) // если изображение в pictureBox2 имеется
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Сохранить картинку как...";
                sfd.OverwritePrompt = true; // показывать ли "Перезаписать файл" если пользователь указывает имя файла, который уже существует
                sfd.CheckPathExists = true; // отображает ли диалоговое окно предупреждение, если пользователь указывает путь, который не существует
                // фильтр форматов файлов
                sfd.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                sfd.ShowHelp = true; // отображается ли кнопка Справка в диалоговом окне
                // если в диалоге была нажата кнопка ОК
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // сохраняем изображение
                        pictureBox2.Image.Save(sfd.FileName);
                    }
                    catch // в случае ошибки выводим MessageBox
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

// кнопка Ч/Б
private void grayButton_Click(object sender, EventArgs e)
{
    if (pictureBox1.Image != null) // если изображение в pictureBox1 имеется
    {
        // создаём Bitmap из изображения, находящегося в pictureBox1
        Bitmap input = new Bitmap(pictureBox1.Image);
        // создаём Bitmap для черно-белого изображения
        Bitmap output = new Bitmap(input.Width, input.Height);
        // перебираем в циклах все пиксели исходного изображения
        for (int j = 0; j < input.Height; j++)
            for (int i = 0; i < input.Width; i++)
            {
                        Color p = input.GetPixel(i, j);

                        int a = p.A;

                        int r = p.R;

                        int g = p.G;

                        int b = p.B;

                        r = 255 - r;

                        g = 255 - g;

                        b = 255 - b;

                        output.SetPixel(i, j, Color.FromArgb(a, r, g, b));
            }
        // выводим черно-белый Bitmap в pictureBox2
        pictureBox2.Image = output;
    }
}
    }
}
