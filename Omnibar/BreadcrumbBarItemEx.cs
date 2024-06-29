using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnibar
{
	internal class BreadcrumbBarItemEx : BreadcrumbBarItem
	{
		public BreadcrumbBarItemEx()
		{
			DefaultStyleKey = typeof(BreadcrumbBarItemEx);
		}

		protected override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			if (GetTemplateChild("PART_ChevronButton") is Button button)
			{
				button.RegisterPropertyChangedCallback(ButtonBase.IsPressedProperty, (sender, args) =>
				{
					VisualStateManager.GoToState(button, "Pressed", true);
					VisualStateManager.GoToState(button, button.IsPressed ? "Expanded" : "NotExpanded", true);
				});

				button.RegisterPropertyChangedCallback(ButtonBase.IsPointerOverProperty, (sender, args) =>
				{
					VisualStateManager.GoToState(button, "PointerOver", true);
				});
			}
		}
	}
}
