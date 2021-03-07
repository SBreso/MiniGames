using MiniGames.Contracts.Bussiness;
using System;
using System.Windows;
using System.Windows.Shapes;

namespace MiniGames.UIGames.GameControls
{
    /// <summary>
    /// Lógica de interacción para ConnectBoard.xaml
    /// </summary>
    public partial class ConnectBoard : BaseBoard, IConnectBoard
    {
        public ConnectCore GameCore { get; private set; }

        public ConnectBoard()
        {
            InitializeComponent();
        }

        public override void OnBoardLoaded()
        {
            this.GameCore = (ConnectCore)this.DataContext;
            this.OnContainerSizeChanged(this.board.ActualHeight, this.board.ActualWidth);
            return;
        }

        public override void OnContainerSizeChanged(double newHeight, double newWidth)
        {
            var newCellHeight = newHeight / (ConnectCore.ROW_COUNT + 1);
            var newCellWidth = newWidth / ConnectCore.COLUMN_COUNT;
            var newCellSize = Math.Min(newCellWidth, newCellHeight);
            this.board.Height = newCellSize * (ConnectCore.ROW_COUNT + 1);
            this.board.Width = newCellSize * (ConnectCore.COLUMN_COUNT);
            ResizePiece(newCellSize);
            ResizeSpaces(newCellSize);
        }
        
        private void ResizePiece(double newDiamtre)
        {
            piece.StrokeThickness = newDiamtre - newDiamtre / 10;
            piece.Height = newDiamtre;
            piece.Width = newDiamtre;
        }

        private void ResizeSpaces(double newDiamtre)
        {
            foreach (var boardChil in this.board.Children)
            {
                if (boardChil is not Ellipse) continue;
                ((Ellipse)boardChil).Width = newDiamtre - newDiamtre / 10;
                ((Ellipse)boardChil).Height = newDiamtre - newDiamtre / 10;
            }            
        }


        private void dock_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            double widthBoard = this.board.ActualWidth;
            double ratio = (piece.Width / 2);
            double x = e.GetPosition(this.board).X;
            if (x >= ratio && x <= widthBoard - ratio)
            {
                piece.Margin = new Thickness((x - ratio), 0, 0, 0);
            }
        }

        private void dock_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            double boardWidth = this.board.ActualWidth;//ancho del tablero
            double x = e.GetPosition(this.board).X;//posicion X del puntero respecto al tablero
            double xCell = boardWidth / ConnectCore.COLUMN_COUNT;//ancho de la celda
            var colum = 0;
            while (colum < ConnectCore.COLUMN_COUNT && x >= (colum + 1) * xCell)//donde deja caer la ficha
            {
                colum++;
            }
        }
    }
}
