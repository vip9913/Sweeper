using System;
using System.Drawing;
using System.Windows.Forms;

namespace SharpSweeper
{
    public partial class Form : System.Windows.Forms.Form
    {
        int wBox, hBox;//ширина и высота каждой клетки
        PictureBox[,] box;//массив картинок
        Mines mines;

        public Form()
        {
            InitializeComponent();
            wBox = panel.Width / Mines.cols;
            hBox = panel.Height / Mines.rows;
            CreateBoxes();
            StartGame();
        }

        /// <summary>
        /// размещение картинок по местам
        /// </summary>
        private void CreateBoxes()
        {
            box = new PictureBox[Mines.cols, Mines.rows];
            for (int x = 0; x < Mines.cols; x++)
                for (int y = 0; y < Mines.rows; y++)
                    box[x, y] = PlaceBox(x,y);
        }

        /// <summary>
        /// инициализация класса логики
        /// </summary>
        public void StartGame()
        {
            
            mines = new Mines(ShowBox);
            pBoxSmile.Image = Properties.Resources.bomb;
            tBoxMine.Text = Mines.total.ToString();
        }
       
        /// <summary>
        /// Изменение размерности при растягивании окна
        /// в данной версии не реализовано
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_Resize(object sender, EventArgs e)
        {
            wBox = panel.Width / Mines.cols;
            hBox = panel.Height / Mines.rows;
            for (int x = 0; x < Mines.cols; x++)
                for (int y = 0; y < Mines.rows; y++)
                {
                    box[x, y].Size = new System.Drawing.Size(wBox, hBox);
                    box[x,y].Location = new System.Drawing.Point(x * wBox, y * hBox);                   
                }  
        }

        /// <summary>
        /// Отрисовка одного квадратика или результат
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="number"></param>
        private void ShowBox(int x, int y, int number)
        {
            box[x, y].Image = ShowPicture(number);
            if (mines!=null) 
                if (mines.gameOver)
                {
                    Form.ActiveForm.Text="Ваша игра окончена сударь(сударыня)!";
                    pBoxSmile.Image = Properties.Resources.bombed;
                }
        }

        /// <summary>
        /// размещение боксиков на форме
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public PictureBox PlaceBox(int x, int y)
        {
            PictureBox onebox = new PictureBox();
            onebox.Image = global::SharpSweeper.Properties.Resources.closed;
            onebox.Location = new System.Drawing.Point(x*wBox, y*hBox);            
            onebox.Size = new System.Drawing.Size(wBox, hBox);
            onebox.SizeMode = PictureBoxSizeMode.StretchImage;
            panel.Controls.Add(onebox);
            onebox.MouseClick += new MouseEventHandler(BoxClicked);
            onebox.Tag = new Point(x,y);
            return onebox;
        }

        /// <summary>
        /// обработка нажатий на боксики
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoxClicked(object sender, MouseEventArgs e)
        {
            Point point = (Point)((PictureBox)sender).Tag;
            int x = point.X;
            int y = point.Y;
            if (e.Button == MouseButtons.Left)
            {
                mines.OpenBox(x, y); //открыть клетку
            }
            else
            if(e.Button == MouseButtons.Right) //пометить клетку
            {
                mines.MarkBox(x,y);
                tBoxMineOpen.Text = mines.placed.ToString();
            }
        }      

        /// <summary>
        /// размещение нужной картинки
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private Image ShowPicture(int number)
        {
            switch (number)
            {
                case   0: return Properties.Resources.zero;
                case   1: return Properties.Resources.num1;
                case   2: return Properties.Resources.num2;
                case   3: return Properties.Resources.num3;
                case   4: return Properties.Resources.num4;
                case   5: return Properties.Resources.num5;
                case   6: return Properties.Resources.num6;
                case   7: return Properties.Resources.num7;
                case   8: return Properties.Resources.num8;
                case  10: return Properties.Resources.bomb;
                case 100: return Properties.Resources.opened;
                case 101: return Properties.Resources.closed;
                case 102: return Properties.Resources.flaged;
                case 103: return Properties.Resources.inform;
                case 104: return Properties.Resources.bombed;

                default: return Properties.Resources.closed;
            }
        }

    }
}
