
using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace NavControllerTutorial
{
	public partial class FontListController : UIViewController
	{
		#region Constructors

		// The IntPtr and initWithCoder constructors are required for controllers that need 
		// to be able to be created from a xib rather than from managed code

		public FontListController (IntPtr handle) : base(handle)
		{
			Initialize ();
		}

		[Export("initWithCoder:")]
		public FontListController (NSCoder coder) : base(coder)
		{
			Initialize ();
		}

		public FontListController () : base("FontListController", null)
		{
			Initialize ();
		}

		void Initialize ()
		{
		}
		
		#endregion
		
		public override void ViewDidLoad ()
		{
			var tv = new UITableView();
			tv.DataSource = new DataSource();
			this.View = tv;
		}
		
		class DataSource : UITableViewDataSource
		{
			public override int NumberOfSections (UITableView tableView)
			{
				return 1;
			}
			
			public override int RowsInSection (UITableView tableview, int section)
			{
				return UIFont.FamilyNames.Length;
			}

			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				var cellIdentifier = "Cell";
				var cell = tableView.DequeueReusableCell(cellIdentifier);
				if(cell == null)
				{
					cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);
				}
				var fontName = UIFont.FamilyNames[indexPath.Row];
				cell.TextLabel.Text = fontName;
				return cell;
			}
		}

		
	}
}
