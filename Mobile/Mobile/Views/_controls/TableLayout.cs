﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms
{
    public class MyTableLayout : Grid
    {
        public MyTableLayout() { }
        public MyTableLayout(int rows, int columns)
        {
            CreateCells(rows, columns);
        }

        void CreateCells(int rows, int columns)
        {
            RowDefinitions.Clear();
            for (int i = 0; i < rows; i++)
            {
                RowDefinitions.Add(new RowDefinition());
            }

            ColumnDefinitions.Clear();
            for (int i = 0; i < columns; i++)
            {
                ColumnDefinitions.Add(new ColumnDefinition());
            }
        }
        public int AddRow()
        {
            var count = RowDefinitions.Count;
            if (count > 0)
            {
                RowDefinitions[count - 1].Height = GridLength.Auto;
            }
            RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            return count;
        }
        public int AddColumn()
        {
            var count = ColumnDefinitions.Count;
            if (count > 0)
            {
                ColumnDefinitions[count - 1].Width = GridLength.Auto;
            }
            ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            return count;
        }

        public void AddRange(params View[] childs)
        {
            foreach (var e in childs)
                Children.Add(e);
        }
        public View Add(View e)
        {
            Children.Add(e);
            return e;
        }
        public View Add(int row, int column, View e)
        {
            if (row > 0) e.SetValue(Grid.RowProperty, row);
            if (column > 0) e.SetValue(Grid.ColumnProperty, column);

            return Add(e);
        }
        public View AddRow(View e)
        {
            var r = AddRow();
            e.SetValue(Grid.RowProperty, r);
            Children.Add(e);

            return e;
        }
        public View AddColumn(View e)
        {
            var c = this.AddColumn();
            e.SetValue(Grid.ColumnProperty, c);

            this.Children.Add(e);
            return e;
        }

        public void SetWidths(GridUnitType type, params int[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (ColumnDefinitions.Count <= i)
                {
                    ColumnDefinitions.Add(new ColumnDefinition());
                }
                int w = values[i];
                if (w > 0)
                {
                    ColumnDefinitions[i].Width = new GridLength(w, type);
                }
            }
        }
        public void SetWidths(params int[] values)
        {
            SetWidths(GridUnitType.Absolute, values);
        }

        public void SetHeights(GridUnitType type, params int[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (RowDefinitions.Count <= i)
                {
                    RowDefinitions.Add(new RowDefinition());
                }
                int w = values[i];
                if (w > 0)
                {
                    RowDefinitions[i].Height = new GridLength(w, type);
                }
            }
        }
        public void SetHeights(params int[] values)
        {
            SetHeights(GridUnitType.Absolute, values);
        }
    }
}
