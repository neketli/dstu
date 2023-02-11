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
    /// ��������� ��� �������� ������������ ����� � ������.
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
            var w = (double)values[1] * .8;//������ ���� ����������. 80% �� ������ �������
            var h = (double)values[2] * .8;//������ ���� ����������. 80% �� ������ �������
            var pg = new PathGeometry();//���������, ������� ����� ����������.
            var ps = new List<PathSegment>();//����� ��������� ����
            //������ �������� �� X
            var rangeX = points.Max(p => p.X) - points.Min(p => p.X);
            //������ �������� �� Y
            var rangeY = points.Max(p => p.Y) - points.Min(p => p.Y);
            //������� �� X
            var scaleX = w / rangeX;
            //������� �� Y
            var scaleY = h / rangeY;
            //�������� �����
            points = points.Select(p => new Point(p.X * scaleX, p.Y * scaleY));
            //�� ������ ��������� �������� ����
            ps.Add(new PolyLineSegment(points, true));
            //�� ��������� ���� ������ ������ � ������ ������ �������.
            var pf = new PathFigure(points.First(), ps, false);
            //��������� ������ � ���������
            pg.Figures.Add(pf);
            //���������� ���������.
            return pg;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}