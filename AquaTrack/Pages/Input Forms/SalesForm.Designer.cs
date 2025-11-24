namespace AquaTrack.Pages.Input_Forms
{
    partial class SalesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesForm));
            siticoneLabelSaleDetails = new SiticoneNetCoreUI.SiticoneLabel();
            siticoneDropdownSaleCustomerName = new SiticoneNetCoreUI.SiticoneDropdown();
            siticoneDTPSaleDate = new SiticoneNetCoreUI.SiticoneDateTimePicker();
            siticoneDropdownSalePaymentMethod = new SiticoneNetCoreUI.SiticoneDropdown();
            siticoneLabelSaleCustomerName = new SiticoneNetCoreUI.SiticoneLabel();
            siticoneLabelSaleDate = new SiticoneNetCoreUI.SiticoneLabel();
            siticoneLabelSalePaymentMethod = new SiticoneNetCoreUI.SiticoneLabel();
            siticoneButtonSaleConfirm = new SiticoneNetCoreUI.SiticoneButton();
            siticoneButtonSaleCancel = new SiticoneNetCoreUI.SiticoneButton();
            siticoneBtnAddSaleItem = new SiticoneNetCoreUI.SiticoneButton();
            saleItemBindingSource = new BindingSource(components);
            siticoneBtnEditSaleItem = new SiticoneNetCoreUI.SiticoneButton();
            siticoneBtnDeleteSaleItem = new SiticoneNetCoreUI.SiticoneButton();
            siticoneDataGridViewSaleItem = new SiticoneNetCoreUI.SiticoneDataGridView();
            saleItemBindingSource1 = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)saleItemBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)siticoneDataGridViewSaleItem).BeginInit();
            ((System.ComponentModel.ISupportInitialize)saleItemBindingSource1).BeginInit();
            SuspendLayout();
            // 
            // siticoneLabelSaleDetails
            // 
            siticoneLabelSaleDetails.BackColor = Color.Transparent;
            siticoneLabelSaleDetails.Font = new Font("Segoe UI", 10F);
            siticoneLabelSaleDetails.Location = new Point(27, 20);
            siticoneLabelSaleDetails.Name = "siticoneLabelSaleDetails";
            siticoneLabelSaleDetails.Size = new Size(100, 23);
            siticoneLabelSaleDetails.TabIndex = 0;
            siticoneLabelSaleDetails.Text = "Sale Details";
            // 
            // siticoneDropdownSaleCustomerName
            // 
            siticoneDropdownSaleCustomerName.AllowMultipleSelection = false;
            siticoneDropdownSaleCustomerName.BackColor = Color.FromArgb(240, 245, 255);
            siticoneDropdownSaleCustomerName.BorderColor = Color.FromArgb(100, 150, 220);
            siticoneDropdownSaleCustomerName.CanBeep = false;
            siticoneDropdownSaleCustomerName.CanShake = true;
            siticoneDropdownSaleCustomerName.DataSource = null;
            siticoneDropdownSaleCustomerName.DisplayMember = null;
            siticoneDropdownSaleCustomerName.DropdownBackColor = Color.FromArgb(245, 250, 255);
            siticoneDropdownSaleCustomerName.DropdownWidth = 0;
            siticoneDropdownSaleCustomerName.DropShadowEnabled = false;
            siticoneDropdownSaleCustomerName.Font = new Font("Segoe UI", 10F);
            siticoneDropdownSaleCustomerName.ForeColor = Color.FromArgb(40, 40, 100);
            siticoneDropdownSaleCustomerName.HoveredItemBackColor = Color.FromArgb(220, 235, 255);
            siticoneDropdownSaleCustomerName.HoveredItemTextColor = Color.FromArgb(40, 40, 100);
            siticoneDropdownSaleCustomerName.IsReadonly = false;
            siticoneDropdownSaleCustomerName.ItemHeight = 30;
            siticoneDropdownSaleCustomerName.Location = new Point(45, 96);
            siticoneDropdownSaleCustomerName.MaxDropDownItems = 8;
            siticoneDropdownSaleCustomerName.Name = "siticoneDropdownSaleCustomerName";
            siticoneDropdownSaleCustomerName.PlaceholderColor = Color.FromArgb(150, 170, 200);
            siticoneDropdownSaleCustomerName.PlaceholderDisappearsOnFocus = false;
            siticoneDropdownSaleCustomerName.PlaceholderText = "Select an option";
            siticoneDropdownSaleCustomerName.SelectedIndex = -1;
            siticoneDropdownSaleCustomerName.SelectedItem = null;
            siticoneDropdownSaleCustomerName.SelectedItemBackColor = Color.FromArgb(70, 130, 220);
            siticoneDropdownSaleCustomerName.SelectedItemTextColor = Color.White;
            siticoneDropdownSaleCustomerName.SelectedValue = null;
            siticoneDropdownSaleCustomerName.Size = new Size(269, 40);
            siticoneDropdownSaleCustomerName.TabIndex = 1;
            siticoneDropdownSaleCustomerName.Text = "siticoneDropdown1";
            siticoneDropdownSaleCustomerName.UnselectedItemTextColor = Color.FromArgb(40, 40, 100);
            siticoneDropdownSaleCustomerName.ValueMember = null;
            siticoneDropdownSaleCustomerName.Click += siticoneDropdownSaleCustomerName_Click;
            // 
            // siticoneDTPSaleDate
            // 
            siticoneDTPSaleDate.AutoScaleFonts = true;
            siticoneDTPSaleDate.BackColor = Color.Transparent;
            siticoneDTPSaleDate.BaseCalendarFormSize = new Size(535, 460);
            siticoneDTPSaleDate.BorderColor = Color.Gray;
            siticoneDTPSaleDate.BorderWidth = 2;
            siticoneDTPSaleDate.BottomLeftBorderRadius = 8;
            siticoneDTPSaleDate.BottomRightBorderRadius = 8;
            siticoneDTPSaleDate.CalendarBackgroundColor = Color.White;
            siticoneDTPSaleDate.CalendarChevronColor = Color.Gray;
            siticoneDTPSaleDate.CalendarChevronHoverColor = Color.Blue;
            siticoneDTPSaleDate.CalendarDayButtonBackColor = Color.White;
            siticoneDTPSaleDate.CalendarDayButtonForeColor = Color.Black;
            siticoneDTPSaleDate.CalendarDayHeaderBackColor = Color.White;
            siticoneDTPSaleDate.CalendarDayHeaderForeColor = Color.FromArgb(100, 100, 100);
            siticoneDTPSaleDate.CalendarDayLabelFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            siticoneDTPSaleDate.CalendarDisabledDateBackColor = Color.LightGray;
            siticoneDTPSaleDate.CalendarDisabledDateForeColor = Color.DarkGray;
            siticoneDTPSaleDate.CalendarFormAnimationSpeed = 15;
            siticoneDTPSaleDate.CalendarFormAnimationStep = 0.08D;
            siticoneDTPSaleDate.CalendarFormBackColor = Color.White;
            siticoneDTPSaleDate.CalendarFormBorderColor = Color.FromArgb(220, 220, 220);
            siticoneDTPSaleDate.CalendarFormBorderWidth = 2;
            siticoneDTPSaleDate.CalendarFormCornerRadius = 2;
            siticoneDTPSaleDate.CalendarFormFadeOutStep = 0.1D;
            siticoneDTPSaleDate.CalendarFormHeight = 460;
            siticoneDTPSaleDate.CalendarFormShadowColor = Color.FromArgb(50, 0, 0, 0);
            siticoneDTPSaleDate.CalendarFormShadowDepth = 5;
            siticoneDTPSaleDate.CalendarFormWidth = 535;
            siticoneDTPSaleDate.CalendarGridMargin = new Padding(8);
            siticoneDTPSaleDate.CalendarGridPadding = new Padding(5);
            siticoneDTPSaleDate.CalendarLockedDateBackColor = Color.LightGray;
            siticoneDTPSaleDate.CalendarLockedDateForeColor = Color.DarkGray;
            siticoneDTPSaleDate.CalendarLockedDates = (List<DateTime>)resources.GetObject("siticoneDTPSaleDate.CalendarLockedDates");
            siticoneDTPSaleDate.CalendarMargin = 5;
            siticoneDTPSaleDate.CalendarMaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            siticoneDTPSaleDate.CalendarMaxYear = 2125;
            siticoneDTPSaleDate.CalendarMinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            siticoneDTPSaleDate.CalendarMinYear = 1925;
            siticoneDTPSaleDate.CalendarRangeDateBackColor = Color.LightBlue;
            siticoneDTPSaleDate.CalendarRangeEndDateBackColor = Color.DodgerBlue;
            siticoneDTPSaleDate.CalendarRangeSelectedForeColor = Color.Black;
            siticoneDTPSaleDate.CalendarRangeStartDateBackColor = Color.DodgerBlue;
            siticoneDTPSaleDate.CalendarSelectedDateBackColor = Color.Black;
            siticoneDTPSaleDate.CalendarSelectedDateForeColor = Color.White;
            siticoneDTPSaleDate.CalendarSelectionMode = SiticoneNetCoreUI.SelectionMode.Single;
            siticoneDTPSaleDate.CalendarTodayBackColor = Color.White;
            siticoneDTPSaleDate.CalendarTodayForeColor = Color.Black;
            siticoneDTPSaleDate.CalendarYearPickerHeight = 10;
            siticoneDTPSaleDate.CanBeep = true;
            siticoneDTPSaleDate.CanShake = true;
            siticoneDTPSaleDate.ChevronColor = Color.Gray;
            siticoneDTPSaleDate.ChevronHoverBackColor = Color.FromArgb(220, 225, 245);
            siticoneDTPSaleDate.ChevronHoverColor = Color.Black;
            siticoneDTPSaleDate.ChevronPanelBorderRadius = 0;
            siticoneDTPSaleDate.ChevronPanelHeight = 32;
            siticoneDTPSaleDate.ChevronPenThickness = 1.8F;
            siticoneDTPSaleDate.ChevronRightMargin = 18;
            siticoneDTPSaleDate.ChevronSize = new Size(9, 14);
            siticoneDTPSaleDate.ChevronStep = 15F;
            siticoneDTPSaleDate.ChevronTimerInterval = 15;
            siticoneDTPSaleDate.ClearIconColor = Color.Gray;
            siticoneDTPSaleDate.ClearIconHoverColor = Color.Red;
            siticoneDTPSaleDate.ClearIconRightMargin = 48;
            siticoneDTPSaleDate.ClearIconSize = 11;
            siticoneDTPSaleDate.ContainerPanelMargin = new Padding(5);
            siticoneDTPSaleDate.ContainerPanelPadding = new Padding(0);
            siticoneDTPSaleDate.CustomDateFormat = "d";
            siticoneDTPSaleDate.CustomDateFormatter = null;
            siticoneDTPSaleDate.DateFormat = SiticoneNetCoreUI.DateFormat.LongDate;
            siticoneDTPSaleDate.DayButtonBorderRadius = 0;
            siticoneDTPSaleDate.DayButtonClickBackColor = Color.FromArgb(220, 230, 250);
            siticoneDTPSaleDate.DayButtonFont = new Font("Segoe UI", 10.5F);
            siticoneDTPSaleDate.DayButtonHoverBackColor = Color.FromArgb(235, 240, 255);
            siticoneDTPSaleDate.DayButtonHoverForeColor = Color.Black;
            siticoneDTPSaleDate.DayButtonMargin = new Padding(3);
            siticoneDTPSaleDate.DayButtonRowHeight = 16.66F;
            siticoneDTPSaleDate.DayHeaderFont = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            siticoneDTPSaleDate.DayHeaderForeColor = Color.FromArgb(100, 100, 100);
            siticoneDTPSaleDate.DayHeaderMargin = new Padding(1, 1, 1, 8);
            siticoneDTPSaleDate.DayHeaderRowHeight = 30F;
            siticoneDTPSaleDate.DisabledDayFont = new Font("Segoe UI", 10F, FontStyle.Italic);
            siticoneDTPSaleDate.DropdownBackColor = Color.White;
            siticoneDTPSaleDate.DropdownFont = new Font("Segoe UI", 11F);
            siticoneDTPSaleDate.DropdownHeight = 250;
            siticoneDTPSaleDate.FillColor = Color.White;
            siticoneDTPSaleDate.FirstDayOfWeek = DayOfWeek.Sunday;
            siticoneDTPSaleDate.Font = new Font("Segoe UI", 10F);
            siticoneDTPSaleDate.ForeColor = Color.DimGray;
            siticoneDTPSaleDate.GradientEndColor = Color.Gray;
            siticoneDTPSaleDate.GradientStartColor = Color.White;
            siticoneDTPSaleDate.HighlightWeekends = true;
            siticoneDTPSaleDate.IconSize = 16;
            siticoneDTPSaleDate.IsReadonly = false;
            siticoneDTPSaleDate.Location = new Point(45, 192);
            siticoneDTPSaleDate.LockedDates = (List<DateTime>)resources.GetObject("siticoneDTPSaleDate.LockedDates");
            siticoneDTPSaleDate.MakeRadial = false;
            siticoneDTPSaleDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            siticoneDTPSaleDate.MaxFontScale = 1.8F;
            siticoneDTPSaleDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            siticoneDTPSaleDate.MinFontScale = 0.4F;
            siticoneDTPSaleDate.MinimumFormSize = new Size(150, 150);
            siticoneDTPSaleDate.MonthChevronPanelMargin = new Padding(4, 17, 4, 0);
            siticoneDTPSaleDate.MonthChevronSpacing = 5;
            siticoneDTPSaleDate.MonthComboBoxMargin = new Padding(0, 17, 5, 0);
            siticoneDTPSaleDate.MonthComboBoxSize = new Size(130, 30);
            siticoneDTPSaleDate.Name = "siticoneDTPSaleDate";
            siticoneDTPSaleDate.NavigationFlowPadding = new Padding(12, 0, 12, 0);
            siticoneDTPSaleDate.NavigationPanelBackColor = Color.FromArgb(245, 245, 250);
            siticoneDTPSaleDate.NavigationPanelHeight = 65;
            siticoneDTPSaleDate.NextMonthPanelWidth = 34;
            siticoneDTPSaleDate.NextYearPanelWidth = 40;
            siticoneDTPSaleDate.PlaceholderText = "Select a date, dates or range...";
            siticoneDTPSaleDate.PrevMonthPanelWidth = 34;
            siticoneDTPSaleDate.PrevYearPanelWidth = 40;
            siticoneDTPSaleDate.RangeStartEndCornerRadius = 0;
            siticoneDTPSaleDate.ReadonlyBorderColor = Color.Gray;
            siticoneDTPSaleDate.ReadonlyFillColor = Color.LightGray;
            siticoneDTPSaleDate.ReadOnlyForeColor = Color.DarkGray;
            siticoneDTPSaleDate.ReadonlyPlaceHolderColor = Color.DarkGray;
            siticoneDTPSaleDate.SelectedDate = null;
            siticoneDTPSaleDate.SelectedDateBorderColor = Color.Black;
            siticoneDTPSaleDate.SelectedDateBorderThickness = 1F;
            siticoneDTPSaleDate.SelectedDates = (List<DateTime>)resources.GetObject("siticoneDTPSaleDate.SelectedDates");
            siticoneDTPSaleDate.SelectionMode = SiticoneNetCoreUI.SelectionMode.Single;
            siticoneDTPSaleDate.ShakeAmplitude = 4;
            siticoneDTPSaleDate.ShakeTimerInterval = 30;
            siticoneDTPSaleDate.ShakeTotalShakes = 8;
            siticoneDTPSaleDate.ShowClearButton = true;
            siticoneDTPSaleDate.ShowMonthYearNavigation = true;
            siticoneDTPSaleDate.ShowTodayButton = true;
            siticoneDTPSaleDate.Size = new Size(269, 45);
            siticoneDTPSaleDate.TabIndex = 2;
            siticoneDTPSaleDate.Text = "siticoneDateTimePicker1";
            siticoneDTPSaleDate.TodayBorderColor = Color.Black;
            siticoneDTPSaleDate.TodayBorderThickness = 2F;
            siticoneDTPSaleDate.TodayButtonBackColor = Color.Black;
            siticoneDTPSaleDate.TodayButtonBorderRadius = 0;
            siticoneDTPSaleDate.TodayButtonClickBackColor = Color.Black;
            siticoneDTPSaleDate.TodayButtonFont = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            siticoneDTPSaleDate.TodayButtonForeColor = Color.White;
            siticoneDTPSaleDate.TodayButtonHoverBackColor = Color.FromArgb(64, 64, 64);
            siticoneDTPSaleDate.TodayButtonMargin = new Padding(0, 17, 15, 0);
            siticoneDTPSaleDate.TodayButtonSize = new Size(70, 35);
            siticoneDTPSaleDate.TodayButtonText = "Today";
            siticoneDTPSaleDate.TodayTextColor = Color.Black;
            siticoneDTPSaleDate.TodayTextFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            siticoneDTPSaleDate.TopLeftBorderRadius = 8;
            siticoneDTPSaleDate.TopRightBorderRadius = 8;
            siticoneDTPSaleDate.UseCalendarFormAnimation = true;
            siticoneDTPSaleDate.UseCalendarFormShadow = true;
            siticoneDTPSaleDate.UseChevronAnimation = true;
            siticoneDTPSaleDate.UseGradientFill = false;
            siticoneDTPSaleDate.Value = null;
            siticoneDTPSaleDate.WeekendDayBackColor = Color.FromArgb(250, 250, 250);
            siticoneDTPSaleDate.WeekendDayForeColor = Color.FromArgb(180, 0, 0);
            siticoneDTPSaleDate.YearChevronPanelMargin = new Padding(4, 17, 4, 0);
            siticoneDTPSaleDate.YearChevronSpacing = 1;
            siticoneDTPSaleDate.YearComboBoxMargin = new Padding(5, 17, 0, 0);
            siticoneDTPSaleDate.YearComboBoxSize = new Size(90, 30);
            // 
            // siticoneDropdownSalePaymentMethod
            // 
            siticoneDropdownSalePaymentMethod.AllowMultipleSelection = false;
            siticoneDropdownSalePaymentMethod.BackColor = Color.FromArgb(240, 245, 255);
            siticoneDropdownSalePaymentMethod.BorderColor = Color.FromArgb(100, 150, 220);
            siticoneDropdownSalePaymentMethod.CanBeep = false;
            siticoneDropdownSalePaymentMethod.CanShake = true;
            siticoneDropdownSalePaymentMethod.DataSource = null;
            siticoneDropdownSalePaymentMethod.DisplayMember = null;
            siticoneDropdownSalePaymentMethod.DropdownBackColor = Color.FromArgb(245, 250, 255);
            siticoneDropdownSalePaymentMethod.DropdownWidth = 0;
            siticoneDropdownSalePaymentMethod.DropShadowEnabled = false;
            siticoneDropdownSalePaymentMethod.Font = new Font("Segoe UI", 10F);
            siticoneDropdownSalePaymentMethod.ForeColor = Color.FromArgb(40, 40, 100);
            siticoneDropdownSalePaymentMethod.HoveredItemBackColor = Color.FromArgb(220, 235, 255);
            siticoneDropdownSalePaymentMethod.HoveredItemTextColor = Color.FromArgb(40, 40, 100);
            siticoneDropdownSalePaymentMethod.IsReadonly = false;
            siticoneDropdownSalePaymentMethod.ItemHeight = 30;
            siticoneDropdownSalePaymentMethod.Items.AddRange(new string[] { "Cash", "Credit Card", "Debit Card", "GCash", "Maya", "" });
            siticoneDropdownSalePaymentMethod.Location = new Point(45, 291);
            siticoneDropdownSalePaymentMethod.MaxDropDownItems = 8;
            siticoneDropdownSalePaymentMethod.Name = "siticoneDropdownSalePaymentMethod";
            siticoneDropdownSalePaymentMethod.PlaceholderColor = Color.FromArgb(150, 170, 200);
            siticoneDropdownSalePaymentMethod.PlaceholderDisappearsOnFocus = false;
            siticoneDropdownSalePaymentMethod.PlaceholderText = "Select an option";
            siticoneDropdownSalePaymentMethod.SelectedIndex = -1;
            siticoneDropdownSalePaymentMethod.SelectedItem = null;
            siticoneDropdownSalePaymentMethod.SelectedItemBackColor = Color.FromArgb(70, 130, 220);
            siticoneDropdownSalePaymentMethod.SelectedItemTextColor = Color.White;
            siticoneDropdownSalePaymentMethod.SelectedValue = null;
            siticoneDropdownSalePaymentMethod.Size = new Size(269, 40);
            siticoneDropdownSalePaymentMethod.TabIndex = 3;
            siticoneDropdownSalePaymentMethod.UnselectedItemTextColor = Color.FromArgb(40, 40, 100);
            siticoneDropdownSalePaymentMethod.ValueMember = null;
            // 
            // siticoneLabelSaleCustomerName
            // 
            siticoneLabelSaleCustomerName.BackColor = Color.Transparent;
            siticoneLabelSaleCustomerName.Font = new Font("Segoe UI", 10F);
            siticoneLabelSaleCustomerName.Location = new Point(45, 70);
            siticoneLabelSaleCustomerName.Name = "siticoneLabelSaleCustomerName";
            siticoneLabelSaleCustomerName.Size = new Size(100, 23);
            siticoneLabelSaleCustomerName.TabIndex = 4;
            siticoneLabelSaleCustomerName.Text = "Customer";
            // 
            // siticoneLabelSaleDate
            // 
            siticoneLabelSaleDate.BackColor = Color.Transparent;
            siticoneLabelSaleDate.Font = new Font("Segoe UI", 10F);
            siticoneLabelSaleDate.Location = new Point(45, 166);
            siticoneLabelSaleDate.Name = "siticoneLabelSaleDate";
            siticoneLabelSaleDate.Size = new Size(100, 23);
            siticoneLabelSaleDate.TabIndex = 5;
            siticoneLabelSaleDate.Text = "Date";
            // 
            // siticoneLabelSalePaymentMethod
            // 
            siticoneLabelSalePaymentMethod.BackColor = Color.Transparent;
            siticoneLabelSalePaymentMethod.Font = new Font("Segoe UI", 10F);
            siticoneLabelSalePaymentMethod.Location = new Point(45, 265);
            siticoneLabelSalePaymentMethod.Name = "siticoneLabelSalePaymentMethod";
            siticoneLabelSalePaymentMethod.Size = new Size(131, 23);
            siticoneLabelSalePaymentMethod.TabIndex = 6;
            siticoneLabelSalePaymentMethod.Text = "Payment Method";
            // 
            // siticoneButtonSaleConfirm
            // 
            siticoneButtonSaleConfirm.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            siticoneButtonSaleConfirm.AccessibleName = "Confirm";
            siticoneButtonSaleConfirm.AutoSizeBasedOnText = false;
            siticoneButtonSaleConfirm.BackColor = Color.Transparent;
            siticoneButtonSaleConfirm.BadgeBackColor = Color.Black;
            siticoneButtonSaleConfirm.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            siticoneButtonSaleConfirm.BadgeValue = 0;
            siticoneButtonSaleConfirm.BadgeValueForeColor = Color.White;
            siticoneButtonSaleConfirm.BorderColor = Color.FromArgb(213, 216, 220);
            siticoneButtonSaleConfirm.BorderWidth = 1;
            siticoneButtonSaleConfirm.ButtonBackColor = Color.FromArgb(245, 247, 250);
            siticoneButtonSaleConfirm.ButtonImage = null;
            siticoneButtonSaleConfirm.ButtonTextLeftPadding = 0;
            siticoneButtonSaleConfirm.CanBeep = true;
            siticoneButtonSaleConfirm.CanGlow = false;
            siticoneButtonSaleConfirm.CanShake = true;
            siticoneButtonSaleConfirm.ContextMenuStripEx = null;
            siticoneButtonSaleConfirm.CornerRadiusBottomLeft = 6;
            siticoneButtonSaleConfirm.CornerRadiusBottomRight = 6;
            siticoneButtonSaleConfirm.CornerRadiusTopLeft = 6;
            siticoneButtonSaleConfirm.CornerRadiusTopRight = 6;
            siticoneButtonSaleConfirm.CustomCursor = Cursors.Default;
            siticoneButtonSaleConfirm.DisabledTextColor = Color.FromArgb(150, 150, 150);
            siticoneButtonSaleConfirm.EnableLongPress = false;
            siticoneButtonSaleConfirm.EnableRippleEffect = true;
            siticoneButtonSaleConfirm.EnableShadow = false;
            siticoneButtonSaleConfirm.EnableTextWrapping = false;
            siticoneButtonSaleConfirm.Font = new Font("Segoe UI Semibold", 10.2F);
            siticoneButtonSaleConfirm.GlowColor = Color.FromArgb(100, 255, 255, 255);
            siticoneButtonSaleConfirm.GlowIntensity = 100;
            siticoneButtonSaleConfirm.GlowRadius = 20F;
            siticoneButtonSaleConfirm.GradientBackground = false;
            siticoneButtonSaleConfirm.GradientColor = Color.FromArgb(0, 227, 64);
            siticoneButtonSaleConfirm.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            siticoneButtonSaleConfirm.HintText = null;
            siticoneButtonSaleConfirm.HoverBackColor = Color.FromArgb(240, 240, 240);
            siticoneButtonSaleConfirm.HoverFontStyle = FontStyle.Regular;
            siticoneButtonSaleConfirm.HoverTextColor = Color.FromArgb(0, 0, 0);
            siticoneButtonSaleConfirm.HoverTransitionDuration = 250;
            siticoneButtonSaleConfirm.ImageAlign = ContentAlignment.MiddleLeft;
            siticoneButtonSaleConfirm.ImagePadding = 5;
            siticoneButtonSaleConfirm.ImageSize = new Size(16, 16);
            siticoneButtonSaleConfirm.IsRadial = false;
            siticoneButtonSaleConfirm.IsReadOnly = false;
            siticoneButtonSaleConfirm.IsToggleButton = false;
            siticoneButtonSaleConfirm.IsToggled = false;
            siticoneButtonSaleConfirm.Location = new Point(45, 364);
            siticoneButtonSaleConfirm.LongPressDurationMS = 1000;
            siticoneButtonSaleConfirm.Name = "siticoneButtonSaleConfirm";
            siticoneButtonSaleConfirm.NormalFontStyle = FontStyle.Regular;
            siticoneButtonSaleConfirm.ParticleColor = Color.FromArgb(200, 200, 200);
            siticoneButtonSaleConfirm.ParticleCount = 15;
            siticoneButtonSaleConfirm.PressAnimationScale = 0.97F;
            siticoneButtonSaleConfirm.PressedBackColor = Color.FromArgb(225, 227, 230);
            siticoneButtonSaleConfirm.PressedFontStyle = FontStyle.Regular;
            siticoneButtonSaleConfirm.PressTransitionDuration = 150;
            siticoneButtonSaleConfirm.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            siticoneButtonSaleConfirm.RippleColor = Color.FromArgb(0, 0, 0);
            siticoneButtonSaleConfirm.RippleRadiusMultiplier = 0.6F;
            siticoneButtonSaleConfirm.ShadowBlur = 5;
            siticoneButtonSaleConfirm.ShadowColor = Color.FromArgb(30, 0, 0, 0);
            siticoneButtonSaleConfirm.ShadowOffset = new Point(0, 2);
            siticoneButtonSaleConfirm.ShakeDuration = 500;
            siticoneButtonSaleConfirm.ShakeIntensity = 5;
            siticoneButtonSaleConfirm.Size = new Size(269, 38);
            siticoneButtonSaleConfirm.TabIndex = 7;
            siticoneButtonSaleConfirm.Text = "Confirm";
            siticoneButtonSaleConfirm.TextAlign = ContentAlignment.MiddleCenter;
            siticoneButtonSaleConfirm.TextColor = Color.FromArgb(0, 0, 0);
            siticoneButtonSaleConfirm.TooltipText = null;
            siticoneButtonSaleConfirm.UseAdvancedRendering = true;
            siticoneButtonSaleConfirm.UseParticles = false;
            siticoneButtonSaleConfirm.Click += siticoneButtonSaleConfirm_Click;
            // 
            // siticoneButtonSaleCancel
            // 
            siticoneButtonSaleCancel.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            siticoneButtonSaleCancel.AccessibleName = "Cancel";
            siticoneButtonSaleCancel.AutoSizeBasedOnText = false;
            siticoneButtonSaleCancel.BackColor = Color.Transparent;
            siticoneButtonSaleCancel.BadgeBackColor = Color.Black;
            siticoneButtonSaleCancel.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            siticoneButtonSaleCancel.BadgeValue = 0;
            siticoneButtonSaleCancel.BadgeValueForeColor = Color.White;
            siticoneButtonSaleCancel.BorderColor = Color.FromArgb(213, 216, 220);
            siticoneButtonSaleCancel.BorderWidth = 1;
            siticoneButtonSaleCancel.ButtonBackColor = Color.FromArgb(245, 247, 250);
            siticoneButtonSaleCancel.ButtonImage = null;
            siticoneButtonSaleCancel.ButtonTextLeftPadding = 0;
            siticoneButtonSaleCancel.CanBeep = true;
            siticoneButtonSaleCancel.CanGlow = false;
            siticoneButtonSaleCancel.CanShake = true;
            siticoneButtonSaleCancel.ContextMenuStripEx = null;
            siticoneButtonSaleCancel.CornerRadiusBottomLeft = 6;
            siticoneButtonSaleCancel.CornerRadiusBottomRight = 6;
            siticoneButtonSaleCancel.CornerRadiusTopLeft = 6;
            siticoneButtonSaleCancel.CornerRadiusTopRight = 6;
            siticoneButtonSaleCancel.CustomCursor = Cursors.Default;
            siticoneButtonSaleCancel.DisabledTextColor = Color.FromArgb(150, 150, 150);
            siticoneButtonSaleCancel.EnableLongPress = false;
            siticoneButtonSaleCancel.EnableRippleEffect = true;
            siticoneButtonSaleCancel.EnableShadow = false;
            siticoneButtonSaleCancel.EnableTextWrapping = false;
            siticoneButtonSaleCancel.Font = new Font("Segoe UI Semibold", 10.2F);
            siticoneButtonSaleCancel.GlowColor = Color.FromArgb(100, 255, 255, 255);
            siticoneButtonSaleCancel.GlowIntensity = 100;
            siticoneButtonSaleCancel.GlowRadius = 20F;
            siticoneButtonSaleCancel.GradientBackground = false;
            siticoneButtonSaleCancel.GradientColor = Color.FromArgb(0, 227, 64);
            siticoneButtonSaleCancel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            siticoneButtonSaleCancel.HintText = null;
            siticoneButtonSaleCancel.HoverBackColor = Color.FromArgb(240, 240, 240);
            siticoneButtonSaleCancel.HoverFontStyle = FontStyle.Regular;
            siticoneButtonSaleCancel.HoverTextColor = Color.FromArgb(0, 0, 0);
            siticoneButtonSaleCancel.HoverTransitionDuration = 250;
            siticoneButtonSaleCancel.ImageAlign = ContentAlignment.MiddleLeft;
            siticoneButtonSaleCancel.ImagePadding = 5;
            siticoneButtonSaleCancel.ImageSize = new Size(16, 16);
            siticoneButtonSaleCancel.IsRadial = false;
            siticoneButtonSaleCancel.IsReadOnly = false;
            siticoneButtonSaleCancel.IsToggleButton = false;
            siticoneButtonSaleCancel.IsToggled = false;
            siticoneButtonSaleCancel.Location = new Point(45, 424);
            siticoneButtonSaleCancel.LongPressDurationMS = 1000;
            siticoneButtonSaleCancel.Name = "siticoneButtonSaleCancel";
            siticoneButtonSaleCancel.NormalFontStyle = FontStyle.Regular;
            siticoneButtonSaleCancel.ParticleColor = Color.FromArgb(200, 200, 200);
            siticoneButtonSaleCancel.ParticleCount = 15;
            siticoneButtonSaleCancel.PressAnimationScale = 0.97F;
            siticoneButtonSaleCancel.PressedBackColor = Color.FromArgb(225, 227, 230);
            siticoneButtonSaleCancel.PressedFontStyle = FontStyle.Regular;
            siticoneButtonSaleCancel.PressTransitionDuration = 150;
            siticoneButtonSaleCancel.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            siticoneButtonSaleCancel.RippleColor = Color.FromArgb(0, 0, 0);
            siticoneButtonSaleCancel.RippleRadiusMultiplier = 0.6F;
            siticoneButtonSaleCancel.ShadowBlur = 5;
            siticoneButtonSaleCancel.ShadowColor = Color.FromArgb(30, 0, 0, 0);
            siticoneButtonSaleCancel.ShadowOffset = new Point(0, 2);
            siticoneButtonSaleCancel.ShakeDuration = 500;
            siticoneButtonSaleCancel.ShakeIntensity = 5;
            siticoneButtonSaleCancel.Size = new Size(269, 38);
            siticoneButtonSaleCancel.TabIndex = 8;
            siticoneButtonSaleCancel.Text = "Cancel";
            siticoneButtonSaleCancel.TextAlign = ContentAlignment.MiddleCenter;
            siticoneButtonSaleCancel.TextColor = Color.FromArgb(0, 0, 0);
            siticoneButtonSaleCancel.TooltipText = null;
            siticoneButtonSaleCancel.UseAdvancedRendering = true;
            siticoneButtonSaleCancel.UseParticles = false;
            siticoneButtonSaleCancel.Click += siticoneButtonSaleCancel_Click;
            // 
            // siticoneBtnAddSaleItem
            // 
            siticoneBtnAddSaleItem.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            siticoneBtnAddSaleItem.AccessibleName = "Add";
            siticoneBtnAddSaleItem.AutoSizeBasedOnText = false;
            siticoneBtnAddSaleItem.BackColor = Color.Transparent;
            siticoneBtnAddSaleItem.BadgeBackColor = Color.Black;
            siticoneBtnAddSaleItem.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            siticoneBtnAddSaleItem.BadgeValue = 0;
            siticoneBtnAddSaleItem.BadgeValueForeColor = Color.White;
            siticoneBtnAddSaleItem.BorderColor = Color.FromArgb(213, 216, 220);
            siticoneBtnAddSaleItem.BorderWidth = 1;
            siticoneBtnAddSaleItem.ButtonBackColor = Color.FromArgb(192, 255, 192);
            siticoneBtnAddSaleItem.ButtonImage = null;
            siticoneBtnAddSaleItem.ButtonTextLeftPadding = 0;
            siticoneBtnAddSaleItem.CanBeep = true;
            siticoneBtnAddSaleItem.CanGlow = false;
            siticoneBtnAddSaleItem.CanShake = true;
            siticoneBtnAddSaleItem.ContextMenuStripEx = null;
            siticoneBtnAddSaleItem.CornerRadiusBottomLeft = 6;
            siticoneBtnAddSaleItem.CornerRadiusBottomRight = 6;
            siticoneBtnAddSaleItem.CornerRadiusTopLeft = 6;
            siticoneBtnAddSaleItem.CornerRadiusTopRight = 6;
            siticoneBtnAddSaleItem.CustomCursor = Cursors.Default;
            siticoneBtnAddSaleItem.DisabledTextColor = Color.FromArgb(150, 150, 150);
            siticoneBtnAddSaleItem.EnableLongPress = false;
            siticoneBtnAddSaleItem.EnableRippleEffect = true;
            siticoneBtnAddSaleItem.EnableShadow = false;
            siticoneBtnAddSaleItem.EnableTextWrapping = false;
            siticoneBtnAddSaleItem.Font = new Font("Segoe UI Semibold", 10.2F);
            siticoneBtnAddSaleItem.GlowColor = Color.FromArgb(100, 255, 255, 255);
            siticoneBtnAddSaleItem.GlowIntensity = 100;
            siticoneBtnAddSaleItem.GlowRadius = 20F;
            siticoneBtnAddSaleItem.GradientBackground = false;
            siticoneBtnAddSaleItem.GradientColor = Color.FromArgb(0, 227, 64);
            siticoneBtnAddSaleItem.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            siticoneBtnAddSaleItem.HintText = null;
            siticoneBtnAddSaleItem.HoverBackColor = Color.FromArgb(240, 240, 240);
            siticoneBtnAddSaleItem.HoverFontStyle = FontStyle.Regular;
            siticoneBtnAddSaleItem.HoverTextColor = Color.FromArgb(0, 0, 0);
            siticoneBtnAddSaleItem.HoverTransitionDuration = 250;
            siticoneBtnAddSaleItem.ImageAlign = ContentAlignment.MiddleLeft;
            siticoneBtnAddSaleItem.ImagePadding = 5;
            siticoneBtnAddSaleItem.ImageSize = new Size(16, 16);
            siticoneBtnAddSaleItem.IsRadial = false;
            siticoneBtnAddSaleItem.IsReadOnly = false;
            siticoneBtnAddSaleItem.IsToggleButton = false;
            siticoneBtnAddSaleItem.IsToggled = false;
            siticoneBtnAddSaleItem.Location = new Point(347, 489);
            siticoneBtnAddSaleItem.LongPressDurationMS = 1000;
            siticoneBtnAddSaleItem.Name = "siticoneBtnAddSaleItem";
            siticoneBtnAddSaleItem.NormalFontStyle = FontStyle.Regular;
            siticoneBtnAddSaleItem.ParticleColor = Color.FromArgb(200, 200, 200);
            siticoneBtnAddSaleItem.ParticleCount = 15;
            siticoneBtnAddSaleItem.PressAnimationScale = 0.97F;
            siticoneBtnAddSaleItem.PressedBackColor = Color.FromArgb(225, 227, 230);
            siticoneBtnAddSaleItem.PressedFontStyle = FontStyle.Regular;
            siticoneBtnAddSaleItem.PressTransitionDuration = 150;
            siticoneBtnAddSaleItem.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            siticoneBtnAddSaleItem.RippleColor = Color.FromArgb(0, 0, 0);
            siticoneBtnAddSaleItem.RippleRadiusMultiplier = 0.6F;
            siticoneBtnAddSaleItem.ShadowBlur = 5;
            siticoneBtnAddSaleItem.ShadowColor = Color.FromArgb(30, 0, 0, 0);
            siticoneBtnAddSaleItem.ShadowOffset = new Point(0, 2);
            siticoneBtnAddSaleItem.ShakeDuration = 500;
            siticoneBtnAddSaleItem.ShakeIntensity = 5;
            siticoneBtnAddSaleItem.Size = new Size(140, 28);
            siticoneBtnAddSaleItem.TabIndex = 11;
            siticoneBtnAddSaleItem.Text = "Add";
            siticoneBtnAddSaleItem.TextAlign = ContentAlignment.MiddleCenter;
            siticoneBtnAddSaleItem.TextColor = Color.FromArgb(0, 0, 0);
            siticoneBtnAddSaleItem.TooltipText = null;
            siticoneBtnAddSaleItem.UseAdvancedRendering = true;
            siticoneBtnAddSaleItem.UseParticles = false;
            siticoneBtnAddSaleItem.Click += siticoneBtnAddSaleItem_Click;
            // 
            // saleItemBindingSource
            // 
            saleItemBindingSource.DataSource = typeof(Models.SaleItem);
            // 
            // siticoneBtnEditSaleItem
            // 
            siticoneBtnEditSaleItem.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            siticoneBtnEditSaleItem.AccessibleName = "Edit";
            siticoneBtnEditSaleItem.AutoSizeBasedOnText = false;
            siticoneBtnEditSaleItem.BackColor = Color.Transparent;
            siticoneBtnEditSaleItem.BadgeBackColor = Color.Black;
            siticoneBtnEditSaleItem.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            siticoneBtnEditSaleItem.BadgeValue = 0;
            siticoneBtnEditSaleItem.BadgeValueForeColor = Color.White;
            siticoneBtnEditSaleItem.BorderColor = Color.FromArgb(213, 216, 220);
            siticoneBtnEditSaleItem.BorderWidth = 1;
            siticoneBtnEditSaleItem.ButtonBackColor = Color.FromArgb(255, 255, 192);
            siticoneBtnEditSaleItem.ButtonImage = null;
            siticoneBtnEditSaleItem.ButtonTextLeftPadding = 0;
            siticoneBtnEditSaleItem.CanBeep = true;
            siticoneBtnEditSaleItem.CanGlow = false;
            siticoneBtnEditSaleItem.CanShake = true;
            siticoneBtnEditSaleItem.ContextMenuStripEx = null;
            siticoneBtnEditSaleItem.CornerRadiusBottomLeft = 6;
            siticoneBtnEditSaleItem.CornerRadiusBottomRight = 6;
            siticoneBtnEditSaleItem.CornerRadiusTopLeft = 6;
            siticoneBtnEditSaleItem.CornerRadiusTopRight = 6;
            siticoneBtnEditSaleItem.CustomCursor = Cursors.Default;
            siticoneBtnEditSaleItem.DisabledTextColor = Color.FromArgb(150, 150, 150);
            siticoneBtnEditSaleItem.EnableLongPress = false;
            siticoneBtnEditSaleItem.EnableRippleEffect = true;
            siticoneBtnEditSaleItem.EnableShadow = false;
            siticoneBtnEditSaleItem.EnableTextWrapping = false;
            siticoneBtnEditSaleItem.Font = new Font("Segoe UI Semibold", 10.2F);
            siticoneBtnEditSaleItem.GlowColor = Color.FromArgb(100, 255, 255, 255);
            siticoneBtnEditSaleItem.GlowIntensity = 100;
            siticoneBtnEditSaleItem.GlowRadius = 20F;
            siticoneBtnEditSaleItem.GradientBackground = false;
            siticoneBtnEditSaleItem.GradientColor = Color.FromArgb(0, 227, 64);
            siticoneBtnEditSaleItem.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            siticoneBtnEditSaleItem.HintText = null;
            siticoneBtnEditSaleItem.HoverBackColor = Color.FromArgb(240, 240, 240);
            siticoneBtnEditSaleItem.HoverFontStyle = FontStyle.Regular;
            siticoneBtnEditSaleItem.HoverTextColor = Color.FromArgb(0, 0, 0);
            siticoneBtnEditSaleItem.HoverTransitionDuration = 250;
            siticoneBtnEditSaleItem.ImageAlign = ContentAlignment.MiddleLeft;
            siticoneBtnEditSaleItem.ImagePadding = 5;
            siticoneBtnEditSaleItem.ImageSize = new Size(16, 16);
            siticoneBtnEditSaleItem.IsRadial = false;
            siticoneBtnEditSaleItem.IsReadOnly = false;
            siticoneBtnEditSaleItem.IsToggleButton = false;
            siticoneBtnEditSaleItem.IsToggled = false;
            siticoneBtnEditSaleItem.Location = new Point(521, 489);
            siticoneBtnEditSaleItem.LongPressDurationMS = 1000;
            siticoneBtnEditSaleItem.Name = "siticoneBtnEditSaleItem";
            siticoneBtnEditSaleItem.NormalFontStyle = FontStyle.Regular;
            siticoneBtnEditSaleItem.ParticleColor = Color.FromArgb(200, 200, 200);
            siticoneBtnEditSaleItem.ParticleCount = 15;
            siticoneBtnEditSaleItem.PressAnimationScale = 0.97F;
            siticoneBtnEditSaleItem.PressedBackColor = Color.FromArgb(225, 227, 230);
            siticoneBtnEditSaleItem.PressedFontStyle = FontStyle.Regular;
            siticoneBtnEditSaleItem.PressTransitionDuration = 150;
            siticoneBtnEditSaleItem.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            siticoneBtnEditSaleItem.RippleColor = Color.FromArgb(0, 0, 0);
            siticoneBtnEditSaleItem.RippleRadiusMultiplier = 0.6F;
            siticoneBtnEditSaleItem.ShadowBlur = 5;
            siticoneBtnEditSaleItem.ShadowColor = Color.FromArgb(30, 0, 0, 0);
            siticoneBtnEditSaleItem.ShadowOffset = new Point(0, 2);
            siticoneBtnEditSaleItem.ShakeDuration = 500;
            siticoneBtnEditSaleItem.ShakeIntensity = 5;
            siticoneBtnEditSaleItem.Size = new Size(159, 28);
            siticoneBtnEditSaleItem.TabIndex = 15;
            siticoneBtnEditSaleItem.Text = "Edit";
            siticoneBtnEditSaleItem.TextAlign = ContentAlignment.MiddleCenter;
            siticoneBtnEditSaleItem.TextColor = Color.FromArgb(0, 0, 0);
            siticoneBtnEditSaleItem.TooltipText = null;
            siticoneBtnEditSaleItem.UseAdvancedRendering = true;
            siticoneBtnEditSaleItem.UseParticles = false;
            // 
            // siticoneBtnDeleteSaleItem
            // 
            siticoneBtnDeleteSaleItem.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            siticoneBtnDeleteSaleItem.AccessibleName = "Delete";
            siticoneBtnDeleteSaleItem.AutoSizeBasedOnText = false;
            siticoneBtnDeleteSaleItem.BackColor = Color.Transparent;
            siticoneBtnDeleteSaleItem.BadgeBackColor = Color.Black;
            siticoneBtnDeleteSaleItem.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            siticoneBtnDeleteSaleItem.BadgeValue = 0;
            siticoneBtnDeleteSaleItem.BadgeValueForeColor = Color.White;
            siticoneBtnDeleteSaleItem.BorderColor = Color.FromArgb(213, 216, 220);
            siticoneBtnDeleteSaleItem.BorderWidth = 1;
            siticoneBtnDeleteSaleItem.ButtonBackColor = Color.FromArgb(255, 192, 192);
            siticoneBtnDeleteSaleItem.ButtonImage = null;
            siticoneBtnDeleteSaleItem.ButtonTextLeftPadding = 0;
            siticoneBtnDeleteSaleItem.CanBeep = true;
            siticoneBtnDeleteSaleItem.CanGlow = false;
            siticoneBtnDeleteSaleItem.CanShake = true;
            siticoneBtnDeleteSaleItem.ContextMenuStripEx = null;
            siticoneBtnDeleteSaleItem.CornerRadiusBottomLeft = 6;
            siticoneBtnDeleteSaleItem.CornerRadiusBottomRight = 6;
            siticoneBtnDeleteSaleItem.CornerRadiusTopLeft = 6;
            siticoneBtnDeleteSaleItem.CornerRadiusTopRight = 6;
            siticoneBtnDeleteSaleItem.CustomCursor = Cursors.Default;
            siticoneBtnDeleteSaleItem.DisabledTextColor = Color.FromArgb(150, 150, 150);
            siticoneBtnDeleteSaleItem.EnableLongPress = false;
            siticoneBtnDeleteSaleItem.EnableRippleEffect = true;
            siticoneBtnDeleteSaleItem.EnableShadow = false;
            siticoneBtnDeleteSaleItem.EnableTextWrapping = false;
            siticoneBtnDeleteSaleItem.Font = new Font("Segoe UI Semibold", 10.2F);
            siticoneBtnDeleteSaleItem.GlowColor = Color.FromArgb(100, 255, 255, 255);
            siticoneBtnDeleteSaleItem.GlowIntensity = 100;
            siticoneBtnDeleteSaleItem.GlowRadius = 20F;
            siticoneBtnDeleteSaleItem.GradientBackground = false;
            siticoneBtnDeleteSaleItem.GradientColor = Color.FromArgb(0, 227, 64);
            siticoneBtnDeleteSaleItem.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            siticoneBtnDeleteSaleItem.HintText = null;
            siticoneBtnDeleteSaleItem.HoverBackColor = Color.FromArgb(240, 240, 240);
            siticoneBtnDeleteSaleItem.HoverFontStyle = FontStyle.Regular;
            siticoneBtnDeleteSaleItem.HoverTextColor = Color.FromArgb(0, 0, 0);
            siticoneBtnDeleteSaleItem.HoverTransitionDuration = 250;
            siticoneBtnDeleteSaleItem.ImageAlign = ContentAlignment.MiddleLeft;
            siticoneBtnDeleteSaleItem.ImagePadding = 5;
            siticoneBtnDeleteSaleItem.ImageSize = new Size(16, 16);
            siticoneBtnDeleteSaleItem.IsRadial = false;
            siticoneBtnDeleteSaleItem.IsReadOnly = false;
            siticoneBtnDeleteSaleItem.IsToggleButton = false;
            siticoneBtnDeleteSaleItem.IsToggled = false;
            siticoneBtnDeleteSaleItem.Location = new Point(702, 489);
            siticoneBtnDeleteSaleItem.LongPressDurationMS = 1000;
            siticoneBtnDeleteSaleItem.Name = "siticoneBtnDeleteSaleItem";
            siticoneBtnDeleteSaleItem.NormalFontStyle = FontStyle.Regular;
            siticoneBtnDeleteSaleItem.ParticleColor = Color.FromArgb(200, 200, 200);
            siticoneBtnDeleteSaleItem.ParticleCount = 15;
            siticoneBtnDeleteSaleItem.PressAnimationScale = 0.97F;
            siticoneBtnDeleteSaleItem.PressedBackColor = Color.FromArgb(225, 227, 230);
            siticoneBtnDeleteSaleItem.PressedFontStyle = FontStyle.Regular;
            siticoneBtnDeleteSaleItem.PressTransitionDuration = 150;
            siticoneBtnDeleteSaleItem.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            siticoneBtnDeleteSaleItem.RippleColor = Color.FromArgb(0, 0, 0);
            siticoneBtnDeleteSaleItem.RippleRadiusMultiplier = 0.6F;
            siticoneBtnDeleteSaleItem.ShadowBlur = 5;
            siticoneBtnDeleteSaleItem.ShadowColor = Color.FromArgb(30, 0, 0, 0);
            siticoneBtnDeleteSaleItem.ShadowOffset = new Point(0, 2);
            siticoneBtnDeleteSaleItem.ShakeDuration = 500;
            siticoneBtnDeleteSaleItem.ShakeIntensity = 5;
            siticoneBtnDeleteSaleItem.Size = new Size(148, 28);
            siticoneBtnDeleteSaleItem.TabIndex = 16;
            siticoneBtnDeleteSaleItem.Text = "Delete";
            siticoneBtnDeleteSaleItem.TextAlign = ContentAlignment.MiddleCenter;
            siticoneBtnDeleteSaleItem.TextColor = Color.FromArgb(0, 0, 0);
            siticoneBtnDeleteSaleItem.TooltipText = null;
            siticoneBtnDeleteSaleItem.UseAdvancedRendering = true;
            siticoneBtnDeleteSaleItem.UseParticles = false;
            // 
            // siticoneDataGridViewSaleItem
            // 
            siticoneDataGridViewSaleItem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            siticoneDataGridViewSaleItem.BackColor = Color.FromArgb(45, 45, 48);
            siticoneDataGridViewSaleItem.CellFont = new Font("Segoe UI", 9.5F);
            siticoneDataGridViewSaleItem.HeaderFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            siticoneDataGridViewSaleItem.Location = new Point(347, 2);
            siticoneDataGridViewSaleItem.Name = "siticoneDataGridViewSaleItem";
            siticoneDataGridViewSaleItem.ShowSampleData = true;
            siticoneDataGridViewSaleItem.Size = new Size(550, 481);
            siticoneDataGridViewSaleItem.TabIndex = 17;
            // 
            // saleItemBindingSource1
            // 
            saleItemBindingSource1.DataSource = typeof(Models.SaleItem);
            // 
            // SalesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(898, 523);
            Controls.Add(siticoneDataGridViewSaleItem);
            Controls.Add(siticoneBtnDeleteSaleItem);
            Controls.Add(siticoneBtnEditSaleItem);
            Controls.Add(siticoneBtnAddSaleItem);
            Controls.Add(siticoneButtonSaleCancel);
            Controls.Add(siticoneButtonSaleConfirm);
            Controls.Add(siticoneLabelSalePaymentMethod);
            Controls.Add(siticoneLabelSaleDate);
            Controls.Add(siticoneLabelSaleCustomerName);
            Controls.Add(siticoneDropdownSalePaymentMethod);
            Controls.Add(siticoneDTPSaleDate);
            Controls.Add(siticoneDropdownSaleCustomerName);
            Controls.Add(siticoneLabelSaleDetails);
            Name = "SalesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SalesForm";
            ((System.ComponentModel.ISupportInitialize)saleItemBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)siticoneDataGridViewSaleItem).EndInit();
            ((System.ComponentModel.ISupportInitialize)saleItemBindingSource1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SiticoneNetCoreUI.SiticoneLabel siticoneLabelSaleDetails;
        private SiticoneNetCoreUI.SiticoneDropdown siticoneDropdownSaleCustomerName;
        private SiticoneNetCoreUI.SiticoneDateTimePicker siticoneDTPSaleDate;
        private SiticoneNetCoreUI.SiticoneDropdown siticoneDropdownSalePaymentMethod;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabelSaleCustomerName;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabelSaleDate;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabelSalePaymentMethod;
        private SiticoneNetCoreUI.SiticoneButton siticoneButtonSaleConfirm;
        private SiticoneNetCoreUI.SiticoneButton siticoneButtonSaleCancel;
        private SiticoneNetCoreUI.SiticoneButton siticoneBtnDeleteCustomer;
        private SiticoneNetCoreUI.SiticoneButton siticoneBtnEditCustomer;
        private SiticoneNetCoreUI.SiticoneButton siticoneBtnAddSaleItem;
        private SiticoneNetCoreUI.SiticoneButton siticoneBtnEditSaleItem;
        private SiticoneNetCoreUI.SiticoneButton siticoneBtnDeleteSaleItem;
        private BindingSource saleItemBindingSource;
        private SiticoneNetCoreUI.SiticoneDataGridView siticoneDataGridViewSaleItem;
        private BindingSource saleItemBindingSource1;
    }
}