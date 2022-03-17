using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace first
{
    /// <summary>
    /// Конвертер для перевода просчитанных точек в фигуру.
    /// </summary>
    public class PointsToPathConverter
        : IMultiValueConverter
    {

        #region Implementation of IMultiValueConverter

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var points = values[0] as IEnumerable<Point>;
            if (points == null)
            {
                return null;
            }
            var w = (double)values[1] * .8;//Ширина зоны построения. 80% от ширины полотна
            var h = (double)values[2] * .8;//Высота зоны построения. 80% от высоты полотна
            var pg = new PathGeometry();//Геометрия, которую будем возвращать.
            var ps = new List<PathSegment>();//Набор сегментов пути
            //Размах значений по X
            var rangeX = points.Max(p => p.X) - points.Min(p => p.X);
            //Размах значений по Y
            var rangeY = points.Max(p => p.Y) - points.Min(p => p.Y);
            //Масштаб по X
            var scaleX = w / rangeX;
            //Масштаб по Y
            var scaleY = h / rangeY;
            //Пересчёт точек
            points = points.Select(p => new Point(p.X * scaleX, p.Y * scaleY));
            //по точкам добавляем сегменты пути
            ps.Add(new PolyLineSegment(points, true));
            //Из сегментов пути строим фигуру с первой точкой вначале.
            var pf = new PathFigure(points.First(), ps, false);
            //Добавляем фигуру в геометрию
            pg.Figures.Add(pf);
            //Возвращаем геометрию.
            return pg;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}