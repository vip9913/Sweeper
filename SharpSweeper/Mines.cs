using System;

namespace SharpSweeper
{
    delegate void deShowBox(int x, int y, int number);

    /// <summary>
    /// класс логики программы
    /// </summary>
    class Mines
    {
        private static Random rnd = new Random();
        public const int cols = 10; //размер поля с минами
        public const int rows = 10;
        public const int total = 10; //количество мин на размещение
        private deShowBox ShowBox;

        public bool gameOver { get; private set; }//результаты игры
        public int placed { get; private set; }   //счетчик расставленных мин

        /// <summary>
        /// 0-пусто
        /// 1-8 -кол-во мин
        /// 10  - мина
        ///  
        /// </summary>
        private int[,] map;//матрица картинок на подложке


        /// <summary>
        /// 100 - открыто
        /// 101 - закрыто
        /// 102 - флаг
        /// 103 - вопрос
        /// 104 - мина грохнулась
        /// </summary>
        private int[,] top;//матрица картинок сверху подложки

        /// <summary>
        /// описание конструктора класса с делегатом от главной формы
        /// </summary>
        /// <param name="ShowBox"></param>
        public Mines(deShowBox ShowBox)
        {
            map = new int[cols, rows];
            top = new int[cols, rows];
            this.ShowBox = ShowBox;
            Init();
            PlaceMines();
        }


        /// <summary>
        /// отображение всех элементов
        /// </summary>
        public void ShowAll()
        {
            for (int x = 0; x < cols; x++)
                for (int y = 0; y < rows; y++)
                {
                    if (top[x, y] == 100) ShowBox(x, y, map[x, y]);
                    else ShowBox(x, y, top[x, y]);
                }
        }

        /// <summary>
        /// Начальная отрисовка поля
        /// </summary>
        public void Init()
        {
            gameOver = false;            
            for (int x = 0; x < cols; x++)
                for (int y = 0; y < rows; y++)
                {
                    map[x, y] = 0;
                    top[x, y] = 101;
                }
        }

        /// <summary>
        /// Размещает на поле мины
        /// </summary>
        public void PlaceMines()
        {
            placed = 0;
            int loop=10000; //предохранительный клапан от зацикливания
            while (placed < total && loop-->0)
            {               
                int x = rnd.Next(0, cols); //случайные координаты
                int y = rnd.Next(0, rows);
                if (map[x, y] == 10) continue;
                map[x, y] = 10; //ставим мину
                for (int sx = -1; sx <=+1; sx++) //перебираем все клетки
                    for (int sy = -1; sy <= +1; sy++)                    
                        PlaceCounter(x + sx, y + sy);
                        placed++;                    
            }
            gameOver = false;
            ShowAll();
        }

        /// <summary>
        /// проверка расстановки мин в пределах поля
        /// увеличивает счетчик в указанной координате
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void PlaceCounter(int x, int y)
        {
            if (!onMap(x,y)) return;          
            if (map[x, y] == 10) return;
            map[x, y]++;
        }

        /// <summary>
        /// открываем клетки поля
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        internal void OpenBox(int x, int y)
        {           
            if (top[x, y] == 102) return;
            if (top[x, y] == 100) //проверяем все отмеченные мины
               {
                    OpenBoxAround(x, y);
                    return;
                }
            if (map[x, y] == 10) //нашли не помеченную мину=конец игры
            {
                gameOver = true;
                OpenAllMines();
                return;
            }
            if (map[x, y] == 0) OpenEmptyBoxes(x,y); //открываем все пустые клетки рядом с открытой
            top[x, y] = 100;
            ShowBox(x,y,map[x,y]);

            if (!OpenedAllBoxes()) return;//если не все мины найдены
            MarkAllMines();
            gameOver = true;           
        }

        /// <summary>
        /// отметить все мины флажками
        /// </summary>
        private void MarkAllMines()
        {
            for (int x = 0; x < cols; x++)
                for (int y = 0; y < rows; y++)
                    if (map[x, y] == 10 && top[x,y]!=100)
                    {
                        top[x, y] = 102;                        
                        ShowBox(x, y, top[x, y]);                        
                    }
        }

        /// <summary>
        /// Проверить все ли клетки кроме минных открыты
        /// </summary>
        /// <returns></returns>
        private bool OpenedAllBoxes()
        {
            for (int x = 0; x < cols; x++)
                for (int y = 0; y < rows; y++)
                    if (map[x, y] != 10 && top[x, y] != 100) //если клетка пустая и закрытая
                        return false;
            return true;
        }

        /// <summary>
        /// откыть все пустые клетки которые рядом с этой
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void OpenEmptyBoxes(int x, int y)
        {
            if (!onMap(x, y)) return;
            if (top[x, y] == 100) return;
            top[x, y] = 100;
            ShowBox(x,y,map[x,y]);
            if (map[x, y] != 0) return;//продолжим открывать клетки если только там пусто
            for (int sx = -1; sx <= +1; sx++) //перебираем все клетки
                for (int sy = -1; sy <= +1; sy++)
                    OpenEmptyBoxes(x+sx, y+sy);
        }

        /// <summary>
        /// проверка на запределы поля игры
        /// </summary>
        /// <param координата ="x"></param>
        /// <param координата ="y"></param>
        private bool onMap(int x, int y)
        {
            if (x < 0 || x >= cols) return false;
            if (y < 0 || y >= rows) return false;
            return true;
        }

        /// <summary>
        /// показать все мины
        /// </summary>
        private void OpenAllMines()
        {
            for (int x = 0; x < cols; x++)
                for (int y = 0; y < rows; y++)
                    if (map[x, y] == 10)
                    {
                        top[x, y] = 100;
                        ShowBox(x,y,map[x,y]);
                    }
        }

        /// <summary>
        /// открыть все клетки вокруг если мины помечены
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void OpenBoxAround(int x, int y)
        {
            int count = 0; //сколько мин отмечено вокруг
            for (int sx = -1; sx <= +1; sx++) //перебираем все клетки соседние
                for (int sy = -1; sy <= +1; sy++)
                    if (onMap(x + sx, y + sy))
                        if (top[x + sx, y + sy] == 102) count++;
            if (count != map[x, y]) return;//не совпало сваливаем
            for (int sx = -1; sx <= +1; sx++) //открываем все клетки
                for (int sy = -1; sy <= +1; sy++)
                    if (onMap(x + sx, y + sy))
                    {
                        if (top[x + sx, y + sy] != 102)
                        {
                            if (map[x + sx, y + sy] == 0) OpenEmptyBoxes(x+sx, y+sy);
                            top[x + sx, y + sy] = 100;
                            if (map[x + sx, y + sy] == 10)
                            {
                                OpenAllMines();
                                gameOver = true;//не угадал
                                return;
                            }
                            ShowBox(x + sx, y + sy, map[x+sx,y+sy]);
                        }
                    }
        }

        /// <summary>
        /// пометить клетку флажком или убрать его если он там был
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        internal void MarkBox(int x, int y)
        {
            if (top[x, y] == 100) return;
            if (top[x, y] == 102)//уже есть флаг
            {
                top[x, y] = 101; //убрать
                placed++;
            }
            else
            {
                top[x, y] = 102;//поставить
                placed--;
            }
            ShowBox(x,y,top[x,y]);
        }
    }
}
