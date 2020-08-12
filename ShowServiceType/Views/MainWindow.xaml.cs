using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using ShowServiceType.Interfaces;
using ShowServiceType.Utils;
using ShowServiceType.ViewModel;

namespace ShowServiceType
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private bool clicked = false;
		private Point lmAbs = new Point();

		/// <summary>
		/// Create Services for work
		/// </summary>
		ILogService Log => Service.CreateLog();
		IExceptionHandler ExceptionHandler => Service.CreateExeptionHandler();
	

		public MainWindow()
		{
			InitializeComponent();
			ServiceConfig.Initialization();
			DataContext = new MainWindowViewModel();
		}


		// ---------------------- Simple methods ----------------------
		#region----------- Simple methods (close/maximize/minimize and etc.) -----------
		void PnMouseMove( object sender , MouseEventArgs e )
		{
			try
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
			catch(Exception ex)
			{
				var log = ExceptionHandler.Handler(ex);
				Log.WriteLog(log);
				MessageBox.Show(log,"Error! ",MessageBoxButton.OK,MessageBoxImage.Error);
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
		private void ScrollViewer_PreviewMouseWheel( object sender , MouseWheelEventArgs e )
		{
			ScrollViewer scroll = (ScrollViewer)sender;
			scroll.ScrollToVerticalOffset(scroll.VerticalOffset - e.Delta);
			e.Handled = true;
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

		private void TreeView_SelectedItemChanged( object sender , RoutedPropertyChangedEventArgs<object> e )
		{
			//check for type
			//if ( sender is ServiceTypeDto item )
			//{
					//check for contains item
			//	if ( lb_SelectedService.Items.Contains(item.Name) )
			//		lb_SelectedService.Items.Remove(item.Name);
			//	else
			//		lb_SelectedService.Items.Add(item.Name);
			//}
		}
	}
}
