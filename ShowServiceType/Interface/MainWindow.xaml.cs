﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShowServiceType
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private bool clicked = false;
		private Point lmAbs = new Point();
		public MainWindow()
		{
			InitializeComponent();
		}


		// ---------------------- Simple methods ----------------------
		#region----------- Simple methods (close/maximize/minimize and etc.) -----------
		void PnMouseMove( object sender , MouseEventArgs e )
		{
			if ( clicked )
			{
				Point MousePosition = e.GetPosition(this);
				Point MousePositionAbs = new Point();
				MousePositionAbs.X = Convert.ToInt16(this.Left) + MousePosition.X;
				MousePositionAbs.Y = Convert.ToInt16(this.Top) + MousePosition.Y;
				this.Left = this.Left + ( MousePositionAbs.X - this.lmAbs.X );
				this.Top = this.Top + ( MousePositionAbs.Y - this.lmAbs.Y );
				this.lmAbs = MousePositionAbs;
			}
		}
		private void Window_MouseLeftButtonDown( object sender , MouseButtonEventArgs e )
		{
			clicked = true;
			this.lmAbs = e.GetPosition(this);
			this.lmAbs.Y = Convert.ToInt16(this.Top) + this.lmAbs.Y;
			this.lmAbs.X = Convert.ToInt16(this.Left) + this.lmAbs.X;
		}
		private void Window_MouseUp( object sender , MouseButtonEventArgs e )
		{
			clicked = false;
		}
		private void btn_Maximize_Click( object sender , RoutedEventArgs e )
		{
			if ( WindowState == WindowState.Normal )
				WindowState = WindowState.Maximized;
			else
				WindowState = WindowState.Normal;
			
		}
		private void btn_Minimize_Click( object sender , RoutedEventArgs e )
		{
			WindowState = WindowState.Minimized;
		}
		private void Btn_Exit_Click( object sender , RoutedEventArgs e )
		{
			Environment.Exit(0);
		}
#endregion
	}
}
