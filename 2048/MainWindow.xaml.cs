using System;
using System.Threading;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace _2048 {
				/// <summary>
				/// MainWindow.xaml 的交互逻辑
				/// </summary>
				public partial class MainWindow : Window {
								Random rand = new Random();
								int c = 0;

								public MainWindow() {
												InitializeComponent();
												addABlock(); addABlock();
								}

								public void addABlock() {
												double d = rand.NextDouble();
												int x = rand.Next(4); int y = rand.Next(4);
												int count = 0;
												foreach (UIElement l in container.Children) {
																if ((Grid.GetColumn(l) == x) && (Grid.GetRow(l) == y)) { count++; c++; Console.WriteLine(c); }
												}
												if (c > 50) { endGame(); }
												else {
																if (count == 0) {
																				c = 0;
																				Label lab = new Label() {
																								Background = Brushes.Orange,
																								BorderBrush = new SolidColorBrush(Color.FromRgb(217, 169, 155)),
																								VerticalContentAlignment = VerticalAlignment.Center,
																								HorizontalContentAlignment = HorizontalAlignment.Center,
																								Foreground = Brushes.White,
																								FontSize = 20
																				};
																				if (d > 0.9) {
																								lab.Content = 4;
																								lab.Background = new SolidColorBrush(Color.FromRgb(240, 224, 200));
																								lab.Foreground = Brushes.Black;
																				}
																				else {
																								lab.Content = 2; lab.Background = new SolidColorBrush(Color.FromRgb(239, 226, 216));
																								lab.Foreground = Brushes.Black;
																				}
																				container.Children.Add(lab);
																				Grid.SetColumn(lab, x); Grid.SetRow(lab, y);
																				NameScope.SetNameScope(this, new NameScope());
																				lab.Name = "lab";
																				this.RegisterName(lab.Name, lab);
																				DoubleAnimation dw = new DoubleAnimation() { From = 0, To = 61, Duration = new Duration(TimeSpan.FromSeconds(0.2)) };
																				Storyboard.SetTargetName(dw, lab.Name);
																				DoubleAnimation dh = new DoubleAnimation() { From = 0, To = 61, Duration = new Duration(TimeSpan.FromSeconds(0.2)) };
																				Storyboard.SetTargetName(dh, lab.Name);
																				Storyboard.SetTargetProperty(dh, new PropertyPath(Label.WidthProperty));
																				Storyboard.SetTargetProperty(dw, new PropertyPath(Label.HeightProperty));
																				Storyboard myStoryboard = new Storyboard();
																				myStoryboard.Children.Add(dw);
																				myStoryboard.Children.Add(dh);
																				myStoryboard.Begin(this);
																}
																else { addABlock(); }
												}
								}

								void endGame() {
												MessageBox.Show("Oops!?");
								}

								private void window_KeyUp(object sender, KeyEventArgs e) {
												if (e.Key == Key.Up) {
																List<string> l1 = new List<string>();
																List<string> l2 = new List<string>();
																List<string> l3 = new List<string>();
																List<string> l4 = new List<string>();
																foreach (Label l in container.Children) {
																				if (Grid.GetColumn(l) == 0) { l1.Add(l.Content.ToString()); }
																				if (Grid.GetColumn(l) == 1) { l2.Add(l.Content.ToString()); }
																				if (Grid.GetColumn(l) == 2) { l3.Add(l.Content.ToString()); }
																				if (Grid.GetColumn(l) == 3) { l4.Add(l.Content.ToString()); }
																}
																List<string> ll1 = formatList(l1);
																List<string> ll2 = formatList(l2);
																List<string> ll3 = formatList(l3);
																List<string> ll4 = formatList(l4);
																container.Children.Clear();
																displayListUp(ll1, 0); displayListUp(ll2, 1); displayListUp(ll3, 2); displayListUp(ll4, 3);
																addABlock();
												}

												if (e.Key == Key.Down) {
																reverseVertically();
																List<string> l1 = new List<string>();
																List<string> l2 = new List<string>();
																List<string> l3 = new List<string>();
																List<string> l4 = new List<string>();
																foreach (Label l in container.Children) {
																				if (Grid.GetColumn(l) == 0) { l1.Add(l.Content.ToString()); }
																				if (Grid.GetColumn(l) == 1) { l2.Add(l.Content.ToString()); }
																				if (Grid.GetColumn(l) == 2) { l3.Add(l.Content.ToString()); }
																				if (Grid.GetColumn(l) == 3) { l4.Add(l.Content.ToString()); }
																}
																List<string> ll1 = formatList(l1);
																List<string> ll2 = formatList(l2);
																List<string> ll3 = formatList(l3);
																List<string> ll4 = formatList(l4);
																container.Children.Clear();
																displayListUp(ll1, 0); displayListUp(ll2, 1); displayListUp(ll3, 2); displayListUp(ll4, 3);
																reverseVertically();
																addABlock();
												}

												if (e.Key == Key.Left) {
																List<string> l1 = new List<string>();
																List<string> l2 = new List<string>();
																List<string> l3 = new List<string>();
																List<string> l4 = new List<string>();
																foreach (Label l in container.Children) {
																				if (Grid.GetRow(l) == 0) { l1.Add(l.Content.ToString()); }
																				if (Grid.GetRow(l) == 1) { l2.Add(l.Content.ToString()); }
																				if (Grid.GetRow(l) == 2) { l3.Add(l.Content.ToString()); }
																				if (Grid.GetRow(l) == 3) { l4.Add(l.Content.ToString()); }
																}
																List<string> ll1 = formatList(l1);
																List<string> ll2 = formatList(l2);
																List<string> ll3 = formatList(l3);
																List<string> ll4 = formatList(l4);
																container.Children.Clear();
																displayListLeft(ll1, 0); displayListLeft(ll2, 1); displayListLeft(ll3, 2); displayListLeft(ll4, 3);
																addABlock();
												}

												if (e.Key == Key.Right) {
																reverseHorizontally();
																List<string> l1 = new List<string>();
																List<string> l2 = new List<string>();
																List<string> l3 = new List<string>();
																List<string> l4 = new List<string>();
																foreach (Label l in container.Children) {
																				if (Grid.GetRow(l) == 0) { l1.Add(l.Content.ToString()); }
																				if (Grid.GetRow(l) == 1) { l2.Add(l.Content.ToString()); }
																				if (Grid.GetRow(l) == 2) { l3.Add(l.Content.ToString()); }
																				if (Grid.GetRow(l) == 3) { l4.Add(l.Content.ToString()); }
																}
																List<string> ll1 = formatList(l1);
																List<string> ll2 = formatList(l2);
																List<string> ll3 = formatList(l3);
																List<string> ll4 = formatList(l4);
																container.Children.Clear();
																displayListLeft(ll1, 0); displayListLeft(ll2, 1); displayListLeft(ll3, 2); displayListLeft(ll4, 3);
																reverseHorizontally();
																addABlock();
												}
								}

								void reverseHorizontally() {
												List<string> l1 = new List<string>();
												List<string> l2 = new List<string>();
												List<string> l3 = new List<string>();
												List<string> l4 = new List<string>();
												for (int i = 0; i < 4; i++) {
																l1.Add(null); l2.Add(null); l3.Add(null); l4.Add(null);
												}
												foreach (Label l in container.Children) {
																if (Grid.GetRow(l) == 0) { l1.RemoveAt(Grid.GetColumn(l)); l1.Insert(Grid.GetColumn(l), l.Content.ToString()); }
																if (Grid.GetRow(l) == 1) { l2.RemoveAt(Grid.GetColumn(l)); l2.Insert(Grid.GetColumn(l), l.Content.ToString()); }
																if (Grid.GetRow(l) == 2) { l3.RemoveAt(Grid.GetColumn(l)); l3.Insert(Grid.GetColumn(l), l.Content.ToString()); }
																if (Grid.GetRow(l) == 3) { l4.RemoveAt(Grid.GetColumn(l)); l4.Insert(Grid.GetColumn(l), l.Content.ToString()); }
												}
												l1.Reverse(); l2.Reverse(); l3.Reverse(); l4.Reverse();
												container.Children.Clear();
												displayListLeft(l1, 0); displayListLeft(l2, 1); displayListLeft(l3, 2); displayListLeft(l4, 3);
								}

								void reverseVertically() {
												List<string> l1 = new List<string>();
												List<string> l2 = new List<string>();
												List<string> l3 = new List<string>();
												List<string> l4 = new List<string>();
												for (int i = 0; i < 4; i++) {
																l1.Add(null); l2.Add(null); l3.Add(null); l4.Add(null);
												}
												foreach (Label l in container.Children) {
																if (Grid.GetColumn(l) == 0) { l1.RemoveAt(Grid.GetRow(l)); l1.Insert(Grid.GetRow(l), l.Content.ToString()); }
																if (Grid.GetColumn(l) == 1) { l2.RemoveAt(Grid.GetRow(l)); l2.Insert(Grid.GetRow(l), l.Content.ToString()); }
																if (Grid.GetColumn(l) == 2) { l3.RemoveAt(Grid.GetRow(l)); l3.Insert(Grid.GetRow(l), l.Content.ToString()); }
																if (Grid.GetColumn(l) == 3) { l4.RemoveAt(Grid.GetRow(l)); l4.Insert(Grid.GetRow(l), l.Content.ToString()); }
												}
												l1.Reverse(); l2.Reverse(); l3.Reverse(); l4.Reverse();
												container.Children.Clear();
												displayListUp(l1, 0); displayListUp(l2, 1); displayListUp(l3, 2); displayListUp(l4, 3);
								}

								List<string> formatList(List<string> l1) {
												string history = "";
												for (int i = 0; i < l1.Count; i++) {
																if (l1[i] == history) {
																				l1[i] = (int.Parse(history) + int.Parse(history)).ToString();
																				if (!((i - 1) == -1)) {
																								l1.RemoveAt(i - 1);
																				}
																}
																if (!(i > (l1.Count - 1))) {
																				history = l1[i];
																}
																else { history = l1[l1.Count - 1]; }
												}
												return l1;
								}

								void displayListLeft(List<string> li, int row) {
												for (int i = 0; i < li.Count; i++) {
																if (!(li[i] == null) && !(li[i] == "")) {
																				Label lab = new Label() {
																								BorderBrush = new SolidColorBrush(Color.FromRgb(217, 169, 155)),
																								Background = Brushes.Orange,
																								Foreground=Brushes.White,
																								VerticalContentAlignment = VerticalAlignment.Center,
																								HorizontalContentAlignment = HorizontalAlignment.Center,
																								FontSize = 20,
																								Content = li[i],
																				};
																				switch(li[i]){
																								case "2":
																												lab.Background = new SolidColorBrush(Color.FromRgb(239, 226, 216));
																												lab.Foreground = Brushes.Black;
																												break;
																								case "4":
																												lab.Background = new SolidColorBrush(Color.FromRgb(240, 224, 200));
																												lab.Foreground = Brushes.Black;
																												break;
																								case "8":
																												lab.Background = new SolidColorBrush(Color.FromRgb(240, 175, 120));
																												break;
																								case "16":
																												lab.Background = new SolidColorBrush(Color.FromRgb(245, 150, 100));
																												break;
																								case "32":
																												lab.Background = new SolidColorBrush(Color.FromRgb(250, 125, 90));
																												break;
																								case "64":
																												lab.Background = new SolidColorBrush(Color.FromRgb(245, 90, 60));
																												break;
																								case "128":
																												lab.Background = new SolidColorBrush(Color.FromRgb(235, 205, 100));
																												break;
																								case "256":
																												lab.Background = new SolidColorBrush(Color.FromRgb(235, 205, 100));
																												break;
																								case "512":
																												lab.Background = new SolidColorBrush(Color.FromRgb(245, 90, 60));
																												break;

																				}
																				container.Children.Add(lab);
																				Grid.SetRow(lab, row);
																				Grid.SetColumn(lab, i);
																}
												}
								}

								void displayListUp(List<string> li, int column) {
												for (int i = 0; i < li.Count; i++) {
																if (!(li[i] == null) && !(li[i] == "")) {
																				Label lab = new Label() {
																								Background = Brushes.Orange,
																								BorderBrush = new SolidColorBrush(Color.FromRgb(217, 169, 155)),
																								VerticalContentAlignment = VerticalAlignment.Center,
																								HorizontalContentAlignment = HorizontalAlignment.Center,
																								Foreground = Brushes.White,
																								FontSize = 20,
																								Content = li[i],
																				};
																				switch (li[i]) {
																								case "2":
																												lab.Background = new SolidColorBrush(Color.FromRgb(239, 226, 216));
																												lab.Foreground = Brushes.Black;
																												break;
																								case "4":
																												lab.Background = new SolidColorBrush(Color.FromRgb(240, 224, 200));
																												lab.Foreground = Brushes.Black;
																												break;
																								case "8":
																												lab.Background = new SolidColorBrush(Color.FromRgb(240, 175, 120));
																												break;
																								case "16":
																												lab.Background = new SolidColorBrush(Color.FromRgb(245, 150, 100));
																												break;
																								case "32":
																												lab.Background = new SolidColorBrush(Color.FromRgb(250, 125, 90));
																												break;
																								case "64":
																												lab.Background = new SolidColorBrush(Color.FromRgb(245, 90, 60));
																												break;
																								case "128":
																												lab.Background = new SolidColorBrush(Color.FromRgb(235, 205, 100));
																												break;
																								case "256":
																												lab.Background = new SolidColorBrush(Color.FromRgb(235, 205, 100));
																												break;
																								case "512":
																												lab.Background = new SolidColorBrush(Color.FromRgb(245, 90, 60));
																												break;
																				}
																				container.Children.Add(lab);
																				Grid.SetRow(lab, i);
																				Grid.SetColumn(lab, column);
																}
												}
								}
				}
}