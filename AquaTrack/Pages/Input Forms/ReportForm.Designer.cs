namespace AquaTrack.Pages.Input_Forms
{
    partial class ReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportForm));
            siticoneLabelReportDetails = new SiticoneNetCoreUI.SiticoneLabel();
            siticoneLabelReportType = new SiticoneNetCoreUI.SiticoneLabel();
            siticoneDropdown1 = new SiticoneNetCoreUI.SiticoneDropdown();
            siticoneLabelReportRangeDate = new SiticoneNetCoreUI.SiticoneLabel();
            siticoneDateTimePicker1 = new SiticoneNetCoreUI.SiticoneDateTimePicker();
            siticoneButtonReportGenerate = new SiticoneNetCoreUI.SiticoneButton();
            siticoneButtonExportReport = new SiticoneNetCoreUI.SiticoneButton();
            siticoneButtonReportCancel = new SiticoneNetCoreUI.SiticoneButton();
            siticoneLabelReportSummary = new SiticoneNetCoreUI.SiticoneLabel();
            siticoneDGVReportSummary = new SiticoneNetCoreUI.SiticoneDataGridView();
            ((System.ComponentModel.ISupportInitialize)siticoneDGVReportSummary).BeginInit();
            SuspendLayout();
            // 
            // siticoneLabelReportDetails
            // 
            siticoneLabelReportDetails.BackColor = Color.Transparent;
            siticoneLabelReportDetails.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            siticoneLabelReportDetails.Location = new Point(9, 9);
            siticoneLabelReportDetails.Name = "siticoneLabelReportDetails";
            siticoneLabelReportDetails.Size = new Size(100, 23);
            siticoneLabelReportDetails.TabIndex = 0;
            siticoneLabelReportDetails.Text = "Report Details";
            // 
            // siticoneLabelReportType
            // 
            siticoneLabelReportType.BackColor = Color.Transparent;
            siticoneLabelReportType.Font = new Font("Segoe UI", 10F);
            siticoneLabelReportType.Location = new Point(48, 88);
            siticoneLabelReportType.Name = "siticoneLabelReportType";
            siticoneLabelReportType.Size = new Size(100, 23);
            siticoneLabelReportType.TabIndex = 2;
            siticoneLabelReportType.Text = "Report Type";
            // 
            // siticoneDropdown1
            // 
            siticoneDropdown1.AllowMultipleSelection = false;
            siticoneDropdown1.BackColor = Color.FromArgb(240, 245, 255);
            siticoneDropdown1.BorderColor = Color.FromArgb(100, 150, 220);
            siticoneDropdown1.CanBeep = false;
            siticoneDropdown1.CanShake = true;
            siticoneDropdown1.DataSource = null;
            siticoneDropdown1.DisplayMember = null;
            siticoneDropdown1.DropdownBackColor = Color.FromArgb(245, 250, 255);
            siticoneDropdown1.DropdownWidth = 0;
            siticoneDropdown1.DropShadowEnabled = false;
            siticoneDropdown1.Font = new Font("Segoe UI", 10F);
            siticoneDropdown1.ForeColor = Color.FromArgb(40, 40, 100);
            siticoneDropdown1.HoveredItemBackColor = Color.FromArgb(220, 235, 255);
            siticoneDropdown1.HoveredItemTextColor = Color.FromArgb(40, 40, 100);
            siticoneDropdown1.IsReadonly = false;
            siticoneDropdown1.ItemHeight = 30;
            siticoneDropdown1.Location = new Point(48, 114);
            siticoneDropdown1.MaxDropDownItems = 8;
            siticoneDropdown1.Name = "siticoneDropdown1";
            siticoneDropdown1.PlaceholderColor = Color.FromArgb(150, 170, 200);
            siticoneDropdown1.PlaceholderDisappearsOnFocus = false;
            siticoneDropdown1.PlaceholderText = "Select an option";
            siticoneDropdown1.SelectedIndex = -1;
            siticoneDropdown1.SelectedItem = null;
            siticoneDropdown1.SelectedItemBackColor = Color.FromArgb(70, 130, 220);
            siticoneDropdown1.SelectedItemTextColor = Color.White;
            siticoneDropdown1.SelectedValue = null;
            siticoneDropdown1.Size = new Size(275, 40);
            siticoneDropdown1.TabIndex = 3;
            siticoneDropdown1.Text = "siticoneDropdownReportType";
            siticoneDropdown1.UnselectedItemTextColor = Color.FromArgb(40, 40, 100);
            siticoneDropdown1.ValueMember = null;
            // 
            // siticoneLabelReportRangeDate
            // 
            siticoneLabelReportRangeDate.BackColor = Color.Transparent;
            siticoneLabelReportRangeDate.Font = new Font("Segoe UI", 10F);
            siticoneLabelReportRangeDate.Location = new Point(48, 176);
            siticoneLabelReportRangeDate.Name = "siticoneLabelReportRangeDate";
            siticoneLabelReportRangeDate.Size = new Size(141, 23);
            siticoneLabelReportRangeDate.TabIndex = 4;
            siticoneLabelReportRangeDate.Text = "Report Range / Date";
            // 
            // siticoneDateTimePicker1
            // 
            siticoneDateTimePicker1.AutoScaleFonts = true;
            siticoneDateTimePicker1.BackColor = Color.Transparent;
            siticoneDateTimePicker1.BaseCalendarFormSize = new Size(535, 460);
            siticoneDateTimePicker1.BorderColor = Color.Gray;
            siticoneDateTimePicker1.BorderWidth = 2;
            siticoneDateTimePicker1.BottomLeftBorderRadius = 8;
            siticoneDateTimePicker1.BottomRightBorderRadius = 8;
            siticoneDateTimePicker1.CalendarBackgroundColor = Color.White;
            siticoneDateTimePicker1.CalendarChevronColor = Color.Gray;
            siticoneDateTimePicker1.CalendarChevronHoverColor = Color.Blue;
            siticoneDateTimePicker1.CalendarDayButtonBackColor = Color.White;
            siticoneDateTimePicker1.CalendarDayButtonForeColor = Color.Black;
            siticoneDateTimePicker1.CalendarDayHeaderBackColor = Color.White;
            siticoneDateTimePicker1.CalendarDayHeaderForeColor = Color.FromArgb(100, 100, 100);
            siticoneDateTimePicker1.CalendarDayLabelFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            siticoneDateTimePicker1.CalendarDisabledDateBackColor = Color.LightGray;
            siticoneDateTimePicker1.CalendarDisabledDateForeColor = Color.DarkGray;
            siticoneDateTimePicker1.CalendarFormAnimationSpeed = 15;
            siticoneDateTimePicker1.CalendarFormAnimationStep = 0.08D;
            siticoneDateTimePicker1.CalendarFormBackColor = Color.White;
            siticoneDateTimePicker1.CalendarFormBorderColor = Color.FromArgb(220, 220, 220);
            siticoneDateTimePicker1.CalendarFormBorderWidth = 2;
            siticoneDateTimePicker1.CalendarFormCornerRadius = 2;
            siticoneDateTimePicker1.CalendarFormFadeOutStep = 0.1D;
            siticoneDateTimePicker1.CalendarFormHeight = 460;
            siticoneDateTimePicker1.CalendarFormShadowColor = Color.FromArgb(50, 0, 0, 0);
            siticoneDateTimePicker1.CalendarFormShadowDepth = 5;
            siticoneDateTimePicker1.CalendarFormWidth = 535;
            siticoneDateTimePicker1.CalendarGridMargin = new Padding(8);
            siticoneDateTimePicker1.CalendarGridPadding = new Padding(5);
            siticoneDateTimePicker1.CalendarLockedDateBackColor = Color.LightGray;
            siticoneDateTimePicker1.CalendarLockedDateForeColor = Color.DarkGray;
            siticoneDateTimePicker1.CalendarLockedDates = (List<DateTime>)resources.GetObject("siticoneDateTimePicker1.CalendarLockedDates");
            siticoneDateTimePicker1.CalendarMargin = 5;
            siticoneDateTimePicker1.CalendarMaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            siticoneDateTimePicker1.CalendarMaxYear = 2125;
            siticoneDateTimePicker1.CalendarMinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            siticoneDateTimePicker1.CalendarMinYear = 1925;
            siticoneDateTimePicker1.CalendarRangeDateBackColor = Color.LightBlue;
            siticoneDateTimePicker1.CalendarRangeEndDateBackColor = Color.DodgerBlue;
            siticoneDateTimePicker1.CalendarRangeSelectedForeColor = Color.Black;
            siticoneDateTimePicker1.CalendarRangeStartDateBackColor = Color.DodgerBlue;
            siticoneDateTimePicker1.CalendarSelectedDateBackColor = Color.Black;
            siticoneDateTimePicker1.CalendarSelectedDateForeColor = Color.White;
            siticoneDateTimePicker1.CalendarSelectionMode = SiticoneNetCoreUI.SelectionMode.Range;
            siticoneDateTimePicker1.CalendarTodayBackColor = Color.White;
            siticoneDateTimePicker1.CalendarTodayForeColor = Color.Black;
            siticoneDateTimePicker1.CalendarYearPickerHeight = 10;
            siticoneDateTimePicker1.CanBeep = true;
            siticoneDateTimePicker1.CanShake = true;
            siticoneDateTimePicker1.ChevronColor = Color.Gray;
            siticoneDateTimePicker1.ChevronHoverBackColor = Color.FromArgb(220, 225, 245);
            siticoneDateTimePicker1.ChevronHoverColor = Color.Black;
            siticoneDateTimePicker1.ChevronPanelBorderRadius = 0;
            siticoneDateTimePicker1.ChevronPanelHeight = 32;
            siticoneDateTimePicker1.ChevronPenThickness = 1.8F;
            siticoneDateTimePicker1.ChevronRightMargin = 18;
            siticoneDateTimePicker1.ChevronSize = new Size(9, 14);
            siticoneDateTimePicker1.ChevronStep = 15F;
            siticoneDateTimePicker1.ChevronTimerInterval = 15;
            siticoneDateTimePicker1.ClearIconColor = Color.Gray;
            siticoneDateTimePicker1.ClearIconHoverColor = Color.Red;
            siticoneDateTimePicker1.ClearIconRightMargin = 48;
            siticoneDateTimePicker1.ClearIconSize = 11;
            siticoneDateTimePicker1.ContainerPanelMargin = new Padding(5);
            siticoneDateTimePicker1.ContainerPanelPadding = new Padding(0);
            siticoneDateTimePicker1.CustomDateFormat = "d";
            siticoneDateTimePicker1.CustomDateFormatter = null;
            siticoneDateTimePicker1.DateFormat = SiticoneNetCoreUI.DateFormat.LongDate;
            siticoneDateTimePicker1.DayButtonBorderRadius = 0;
            siticoneDateTimePicker1.DayButtonClickBackColor = Color.FromArgb(220, 230, 250);
            siticoneDateTimePicker1.DayButtonFont = new Font("Segoe UI", 10.5F);
            siticoneDateTimePicker1.DayButtonHoverBackColor = Color.FromArgb(235, 240, 255);
            siticoneDateTimePicker1.DayButtonHoverForeColor = Color.Black;
            siticoneDateTimePicker1.DayButtonMargin = new Padding(3);
            siticoneDateTimePicker1.DayButtonRowHeight = 16.66F;
            siticoneDateTimePicker1.DayHeaderFont = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            siticoneDateTimePicker1.DayHeaderForeColor = Color.FromArgb(100, 100, 100);
            siticoneDateTimePicker1.DayHeaderMargin = new Padding(1, 1, 1, 8);
            siticoneDateTimePicker1.DayHeaderRowHeight = 30F;
            siticoneDateTimePicker1.DisabledDayFont = new Font("Segoe UI", 10F, FontStyle.Italic);
            siticoneDateTimePicker1.DropdownBackColor = Color.White;
            siticoneDateTimePicker1.DropdownFont = new Font("Segoe UI", 11F);
            siticoneDateTimePicker1.DropdownHeight = 250;
            siticoneDateTimePicker1.FillColor = Color.White;
            siticoneDateTimePicker1.FirstDayOfWeek = DayOfWeek.Sunday;
            siticoneDateTimePicker1.Font = new Font("Segoe UI", 10F);
            siticoneDateTimePicker1.ForeColor = Color.DimGray;
            siticoneDateTimePicker1.GradientEndColor = Color.Gray;
            siticoneDateTimePicker1.GradientStartColor = Color.White;
            siticoneDateTimePicker1.HighlightWeekends = true;
            siticoneDateTimePicker1.IconSize = 16;
            siticoneDateTimePicker1.IsReadonly = false;
            siticoneDateTimePicker1.Location = new Point(48, 202);
            siticoneDateTimePicker1.LockedDates = (List<DateTime>)resources.GetObject("siticoneDateTimePicker1.LockedDates");
            siticoneDateTimePicker1.MakeRadial = false;
            siticoneDateTimePicker1.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            siticoneDateTimePicker1.MaxFontScale = 1.8F;
            siticoneDateTimePicker1.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            siticoneDateTimePicker1.MinFontScale = 0.4F;
            siticoneDateTimePicker1.MinimumFormSize = new Size(150, 150);
            siticoneDateTimePicker1.MonthChevronPanelMargin = new Padding(4, 17, 4, 0);
            siticoneDateTimePicker1.MonthChevronSpacing = 5;
            siticoneDateTimePicker1.MonthComboBoxMargin = new Padding(0, 17, 5, 0);
            siticoneDateTimePicker1.MonthComboBoxSize = new Size(130, 30);
            siticoneDateTimePicker1.Name = "siticoneDateTimePicker1";
            siticoneDateTimePicker1.NavigationFlowPadding = new Padding(12, 0, 12, 0);
            siticoneDateTimePicker1.NavigationPanelBackColor = Color.FromArgb(245, 245, 250);
            siticoneDateTimePicker1.NavigationPanelHeight = 65;
            siticoneDateTimePicker1.NextMonthPanelWidth = 34;
            siticoneDateTimePicker1.NextYearPanelWidth = 40;
            siticoneDateTimePicker1.PlaceholderText = "Select a date, dates or range...";
            siticoneDateTimePicker1.PrevMonthPanelWidth = 34;
            siticoneDateTimePicker1.PrevYearPanelWidth = 40;
            siticoneDateTimePicker1.RangeStartEndCornerRadius = 0;
            siticoneDateTimePicker1.ReadonlyBorderColor = Color.Gray;
            siticoneDateTimePicker1.ReadonlyFillColor = Color.LightGray;
            siticoneDateTimePicker1.ReadOnlyForeColor = Color.DarkGray;
            siticoneDateTimePicker1.ReadonlyPlaceHolderColor = Color.DarkGray;
            siticoneDateTimePicker1.SelectedDate = null;
            siticoneDateTimePicker1.SelectedDateBorderColor = Color.Black;
            siticoneDateTimePicker1.SelectedDateBorderThickness = 1F;
            siticoneDateTimePicker1.SelectedDates = (List<DateTime>)resources.GetObject("siticoneDateTimePicker1.SelectedDates");
            siticoneDateTimePicker1.SelectionMode = SiticoneNetCoreUI.SelectionMode.Range;
            siticoneDateTimePicker1.ShakeAmplitude = 4;
            siticoneDateTimePicker1.ShakeTimerInterval = 30;
            siticoneDateTimePicker1.ShakeTotalShakes = 8;
            siticoneDateTimePicker1.ShowClearButton = true;
            siticoneDateTimePicker1.ShowMonthYearNavigation = true;
            siticoneDateTimePicker1.ShowTodayButton = true;
            siticoneDateTimePicker1.Size = new Size(275, 45);
            siticoneDateTimePicker1.TabIndex = 5;
            siticoneDateTimePicker1.Text = "siticoneDateTimePicker1";
            siticoneDateTimePicker1.TodayBorderColor = Color.Black;
            siticoneDateTimePicker1.TodayBorderThickness = 2F;
            siticoneDateTimePicker1.TodayButtonBackColor = Color.Black;
            siticoneDateTimePicker1.TodayButtonBorderRadius = 0;
            siticoneDateTimePicker1.TodayButtonClickBackColor = Color.Black;
            siticoneDateTimePicker1.TodayButtonFont = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            siticoneDateTimePicker1.TodayButtonForeColor = Color.White;
            siticoneDateTimePicker1.TodayButtonHoverBackColor = Color.FromArgb(64, 64, 64);
            siticoneDateTimePicker1.TodayButtonMargin = new Padding(0, 17, 15, 0);
            siticoneDateTimePicker1.TodayButtonSize = new Size(70, 35);
            siticoneDateTimePicker1.TodayButtonText = "Today";
            siticoneDateTimePicker1.TodayTextColor = Color.Black;
            siticoneDateTimePicker1.TodayTextFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            siticoneDateTimePicker1.TopLeftBorderRadius = 8;
            siticoneDateTimePicker1.TopRightBorderRadius = 8;
            siticoneDateTimePicker1.UseCalendarFormAnimation = true;
            siticoneDateTimePicker1.UseCalendarFormShadow = true;
            siticoneDateTimePicker1.UseChevronAnimation = true;
            siticoneDateTimePicker1.UseGradientFill = false;
            siticoneDateTimePicker1.Value = null;
            siticoneDateTimePicker1.WeekendDayBackColor = Color.FromArgb(250, 250, 250);
            siticoneDateTimePicker1.WeekendDayForeColor = Color.FromArgb(180, 0, 0);
            siticoneDateTimePicker1.YearChevronPanelMargin = new Padding(4, 17, 4, 0);
            siticoneDateTimePicker1.YearChevronSpacing = 1;
            siticoneDateTimePicker1.YearComboBoxMargin = new Padding(5, 17, 0, 0);
            siticoneDateTimePicker1.YearComboBoxSize = new Size(90, 30);
            // 
            // siticoneButtonReportGenerate
            // 
            siticoneButtonReportGenerate.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            siticoneButtonReportGenerate.AccessibleName = "Generate";
            siticoneButtonReportGenerate.AutoSizeBasedOnText = false;
            siticoneButtonReportGenerate.BackColor = Color.Transparent;
            siticoneButtonReportGenerate.BadgeBackColor = Color.Black;
            siticoneButtonReportGenerate.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            siticoneButtonReportGenerate.BadgeValue = 0;
            siticoneButtonReportGenerate.BadgeValueForeColor = Color.White;
            siticoneButtonReportGenerate.BorderColor = Color.FromArgb(213, 216, 220);
            siticoneButtonReportGenerate.BorderWidth = 1;
            siticoneButtonReportGenerate.ButtonBackColor = Color.FromArgb(245, 247, 250);
            siticoneButtonReportGenerate.ButtonImage = null;
            siticoneButtonReportGenerate.ButtonTextLeftPadding = 0;
            siticoneButtonReportGenerate.CanBeep = true;
            siticoneButtonReportGenerate.CanGlow = false;
            siticoneButtonReportGenerate.CanShake = true;
            siticoneButtonReportGenerate.ContextMenuStripEx = null;
            siticoneButtonReportGenerate.CornerRadiusBottomLeft = 6;
            siticoneButtonReportGenerate.CornerRadiusBottomRight = 6;
            siticoneButtonReportGenerate.CornerRadiusTopLeft = 6;
            siticoneButtonReportGenerate.CornerRadiusTopRight = 6;
            siticoneButtonReportGenerate.CustomCursor = Cursors.Default;
            siticoneButtonReportGenerate.DisabledTextColor = Color.FromArgb(150, 150, 150);
            siticoneButtonReportGenerate.EnableLongPress = false;
            siticoneButtonReportGenerate.EnableRippleEffect = true;
            siticoneButtonReportGenerate.EnableShadow = false;
            siticoneButtonReportGenerate.EnableTextWrapping = false;
            siticoneButtonReportGenerate.Font = new Font("Segoe UI Semibold", 10.2F);
            siticoneButtonReportGenerate.GlowColor = Color.FromArgb(100, 255, 255, 255);
            siticoneButtonReportGenerate.GlowIntensity = 100;
            siticoneButtonReportGenerate.GlowRadius = 20F;
            siticoneButtonReportGenerate.GradientBackground = false;
            siticoneButtonReportGenerate.GradientColor = Color.FromArgb(0, 227, 64);
            siticoneButtonReportGenerate.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            siticoneButtonReportGenerate.HintText = null;
            siticoneButtonReportGenerate.HoverBackColor = Color.FromArgb(240, 240, 240);
            siticoneButtonReportGenerate.HoverFontStyle = FontStyle.Regular;
            siticoneButtonReportGenerate.HoverTextColor = Color.FromArgb(0, 0, 0);
            siticoneButtonReportGenerate.HoverTransitionDuration = 250;
            siticoneButtonReportGenerate.ImageAlign = ContentAlignment.MiddleLeft;
            siticoneButtonReportGenerate.ImagePadding = 5;
            siticoneButtonReportGenerate.ImageSize = new Size(16, 16);
            siticoneButtonReportGenerate.IsRadial = false;
            siticoneButtonReportGenerate.IsReadOnly = false;
            siticoneButtonReportGenerate.IsToggleButton = false;
            siticoneButtonReportGenerate.IsToggled = false;
            siticoneButtonReportGenerate.Location = new Point(48, 287);
            siticoneButtonReportGenerate.LongPressDurationMS = 1000;
            siticoneButtonReportGenerate.Name = "siticoneButtonReportGenerate";
            siticoneButtonReportGenerate.NormalFontStyle = FontStyle.Regular;
            siticoneButtonReportGenerate.ParticleColor = Color.FromArgb(200, 200, 200);
            siticoneButtonReportGenerate.ParticleCount = 15;
            siticoneButtonReportGenerate.PressAnimationScale = 0.97F;
            siticoneButtonReportGenerate.PressedBackColor = Color.FromArgb(225, 227, 230);
            siticoneButtonReportGenerate.PressedFontStyle = FontStyle.Regular;
            siticoneButtonReportGenerate.PressTransitionDuration = 150;
            siticoneButtonReportGenerate.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            siticoneButtonReportGenerate.RippleColor = Color.FromArgb(0, 0, 0);
            siticoneButtonReportGenerate.RippleRadiusMultiplier = 0.6F;
            siticoneButtonReportGenerate.ShadowBlur = 5;
            siticoneButtonReportGenerate.ShadowColor = Color.FromArgb(30, 0, 0, 0);
            siticoneButtonReportGenerate.ShadowOffset = new Point(0, 2);
            siticoneButtonReportGenerate.ShakeDuration = 500;
            siticoneButtonReportGenerate.ShakeIntensity = 5;
            siticoneButtonReportGenerate.Size = new Size(275, 39);
            siticoneButtonReportGenerate.TabIndex = 6;
            siticoneButtonReportGenerate.Text = "Generate";
            siticoneButtonReportGenerate.TextAlign = ContentAlignment.MiddleCenter;
            siticoneButtonReportGenerate.TextColor = Color.FromArgb(0, 0, 0);
            siticoneButtonReportGenerate.TooltipText = null;
            siticoneButtonReportGenerate.UseAdvancedRendering = true;
            siticoneButtonReportGenerate.UseParticles = false;
            // 
            // siticoneButtonExportReport
            // 
            siticoneButtonExportReport.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            siticoneButtonExportReport.AccessibleName = "Export to PDF";
            siticoneButtonExportReport.AutoSizeBasedOnText = false;
            siticoneButtonExportReport.BackColor = Color.Transparent;
            siticoneButtonExportReport.BadgeBackColor = Color.Black;
            siticoneButtonExportReport.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            siticoneButtonExportReport.BadgeValue = 0;
            siticoneButtonExportReport.BadgeValueForeColor = Color.White;
            siticoneButtonExportReport.BorderColor = Color.FromArgb(213, 216, 220);
            siticoneButtonExportReport.BorderWidth = 1;
            siticoneButtonExportReport.ButtonBackColor = Color.FromArgb(245, 247, 250);
            siticoneButtonExportReport.ButtonImage = null;
            siticoneButtonExportReport.ButtonTextLeftPadding = 0;
            siticoneButtonExportReport.CanBeep = true;
            siticoneButtonExportReport.CanGlow = false;
            siticoneButtonExportReport.CanShake = true;
            siticoneButtonExportReport.ContextMenuStripEx = null;
            siticoneButtonExportReport.CornerRadiusBottomLeft = 6;
            siticoneButtonExportReport.CornerRadiusBottomRight = 6;
            siticoneButtonExportReport.CornerRadiusTopLeft = 6;
            siticoneButtonExportReport.CornerRadiusTopRight = 6;
            siticoneButtonExportReport.CustomCursor = Cursors.Default;
            siticoneButtonExportReport.DisabledTextColor = Color.FromArgb(150, 150, 150);
            siticoneButtonExportReport.EnableLongPress = false;
            siticoneButtonExportReport.EnableRippleEffect = true;
            siticoneButtonExportReport.EnableShadow = false;
            siticoneButtonExportReport.EnableTextWrapping = false;
            siticoneButtonExportReport.Font = new Font("Segoe UI Semibold", 10.2F);
            siticoneButtonExportReport.GlowColor = Color.FromArgb(100, 255, 255, 255);
            siticoneButtonExportReport.GlowIntensity = 100;
            siticoneButtonExportReport.GlowRadius = 20F;
            siticoneButtonExportReport.GradientBackground = false;
            siticoneButtonExportReport.GradientColor = Color.FromArgb(0, 227, 64);
            siticoneButtonExportReport.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            siticoneButtonExportReport.HintText = null;
            siticoneButtonExportReport.HoverBackColor = Color.FromArgb(240, 240, 240);
            siticoneButtonExportReport.HoverFontStyle = FontStyle.Regular;
            siticoneButtonExportReport.HoverTextColor = Color.FromArgb(0, 0, 0);
            siticoneButtonExportReport.HoverTransitionDuration = 250;
            siticoneButtonExportReport.ImageAlign = ContentAlignment.MiddleLeft;
            siticoneButtonExportReport.ImagePadding = 5;
            siticoneButtonExportReport.ImageSize = new Size(16, 16);
            siticoneButtonExportReport.IsRadial = false;
            siticoneButtonExportReport.IsReadOnly = false;
            siticoneButtonExportReport.IsToggleButton = false;
            siticoneButtonExportReport.IsToggled = false;
            siticoneButtonExportReport.Location = new Point(48, 356);
            siticoneButtonExportReport.LongPressDurationMS = 1000;
            siticoneButtonExportReport.Name = "siticoneButtonExportReport";
            siticoneButtonExportReport.NormalFontStyle = FontStyle.Regular;
            siticoneButtonExportReport.ParticleColor = Color.FromArgb(200, 200, 200);
            siticoneButtonExportReport.ParticleCount = 15;
            siticoneButtonExportReport.PressAnimationScale = 0.97F;
            siticoneButtonExportReport.PressedBackColor = Color.FromArgb(225, 227, 230);
            siticoneButtonExportReport.PressedFontStyle = FontStyle.Regular;
            siticoneButtonExportReport.PressTransitionDuration = 150;
            siticoneButtonExportReport.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            siticoneButtonExportReport.RippleColor = Color.FromArgb(0, 0, 0);
            siticoneButtonExportReport.RippleRadiusMultiplier = 0.6F;
            siticoneButtonExportReport.ShadowBlur = 5;
            siticoneButtonExportReport.ShadowColor = Color.FromArgb(30, 0, 0, 0);
            siticoneButtonExportReport.ShadowOffset = new Point(0, 2);
            siticoneButtonExportReport.ShakeDuration = 500;
            siticoneButtonExportReport.ShakeIntensity = 5;
            siticoneButtonExportReport.Size = new Size(275, 39);
            siticoneButtonExportReport.TabIndex = 7;
            siticoneButtonExportReport.Text = "Export to PDF";
            siticoneButtonExportReport.TextAlign = ContentAlignment.MiddleCenter;
            siticoneButtonExportReport.TextColor = Color.FromArgb(0, 0, 0);
            siticoneButtonExportReport.TooltipText = null;
            siticoneButtonExportReport.UseAdvancedRendering = true;
            siticoneButtonExportReport.UseParticles = false;
            // 
            // siticoneButtonReportCancel
            // 
            siticoneButtonReportCancel.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            siticoneButtonReportCancel.AccessibleName = "Cancel";
            siticoneButtonReportCancel.AutoSizeBasedOnText = false;
            siticoneButtonReportCancel.BackColor = Color.Transparent;
            siticoneButtonReportCancel.BadgeBackColor = Color.Black;
            siticoneButtonReportCancel.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            siticoneButtonReportCancel.BadgeValue = 0;
            siticoneButtonReportCancel.BadgeValueForeColor = Color.White;
            siticoneButtonReportCancel.BorderColor = Color.FromArgb(213, 216, 220);
            siticoneButtonReportCancel.BorderWidth = 1;
            siticoneButtonReportCancel.ButtonBackColor = Color.FromArgb(245, 247, 250);
            siticoneButtonReportCancel.ButtonImage = null;
            siticoneButtonReportCancel.ButtonTextLeftPadding = 0;
            siticoneButtonReportCancel.CanBeep = true;
            siticoneButtonReportCancel.CanGlow = false;
            siticoneButtonReportCancel.CanShake = true;
            siticoneButtonReportCancel.ContextMenuStripEx = null;
            siticoneButtonReportCancel.CornerRadiusBottomLeft = 6;
            siticoneButtonReportCancel.CornerRadiusBottomRight = 6;
            siticoneButtonReportCancel.CornerRadiusTopLeft = 6;
            siticoneButtonReportCancel.CornerRadiusTopRight = 6;
            siticoneButtonReportCancel.CustomCursor = Cursors.Default;
            siticoneButtonReportCancel.DisabledTextColor = Color.FromArgb(150, 150, 150);
            siticoneButtonReportCancel.EnableLongPress = false;
            siticoneButtonReportCancel.EnableRippleEffect = true;
            siticoneButtonReportCancel.EnableShadow = false;
            siticoneButtonReportCancel.EnableTextWrapping = false;
            siticoneButtonReportCancel.Font = new Font("Segoe UI Semibold", 10.2F);
            siticoneButtonReportCancel.GlowColor = Color.FromArgb(100, 255, 255, 255);
            siticoneButtonReportCancel.GlowIntensity = 100;
            siticoneButtonReportCancel.GlowRadius = 20F;
            siticoneButtonReportCancel.GradientBackground = false;
            siticoneButtonReportCancel.GradientColor = Color.FromArgb(0, 227, 64);
            siticoneButtonReportCancel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            siticoneButtonReportCancel.HintText = null;
            siticoneButtonReportCancel.HoverBackColor = Color.FromArgb(240, 240, 240);
            siticoneButtonReportCancel.HoverFontStyle = FontStyle.Regular;
            siticoneButtonReportCancel.HoverTextColor = Color.FromArgb(0, 0, 0);
            siticoneButtonReportCancel.HoverTransitionDuration = 250;
            siticoneButtonReportCancel.ImageAlign = ContentAlignment.MiddleLeft;
            siticoneButtonReportCancel.ImagePadding = 5;
            siticoneButtonReportCancel.ImageSize = new Size(16, 16);
            siticoneButtonReportCancel.IsRadial = false;
            siticoneButtonReportCancel.IsReadOnly = false;
            siticoneButtonReportCancel.IsToggleButton = false;
            siticoneButtonReportCancel.IsToggled = false;
            siticoneButtonReportCancel.Location = new Point(48, 423);
            siticoneButtonReportCancel.LongPressDurationMS = 1000;
            siticoneButtonReportCancel.Name = "siticoneButtonReportCancel";
            siticoneButtonReportCancel.NormalFontStyle = FontStyle.Regular;
            siticoneButtonReportCancel.ParticleColor = Color.FromArgb(200, 200, 200);
            siticoneButtonReportCancel.ParticleCount = 15;
            siticoneButtonReportCancel.PressAnimationScale = 0.97F;
            siticoneButtonReportCancel.PressedBackColor = Color.FromArgb(225, 227, 230);
            siticoneButtonReportCancel.PressedFontStyle = FontStyle.Regular;
            siticoneButtonReportCancel.PressTransitionDuration = 150;
            siticoneButtonReportCancel.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            siticoneButtonReportCancel.RippleColor = Color.FromArgb(0, 0, 0);
            siticoneButtonReportCancel.RippleRadiusMultiplier = 0.6F;
            siticoneButtonReportCancel.ShadowBlur = 5;
            siticoneButtonReportCancel.ShadowColor = Color.FromArgb(30, 0, 0, 0);
            siticoneButtonReportCancel.ShadowOffset = new Point(0, 2);
            siticoneButtonReportCancel.ShakeDuration = 500;
            siticoneButtonReportCancel.ShakeIntensity = 5;
            siticoneButtonReportCancel.Size = new Size(275, 39);
            siticoneButtonReportCancel.TabIndex = 8;
            siticoneButtonReportCancel.Text = "Cancel";
            siticoneButtonReportCancel.TextAlign = ContentAlignment.MiddleCenter;
            siticoneButtonReportCancel.TextColor = Color.FromArgb(0, 0, 0);
            siticoneButtonReportCancel.TooltipText = null;
            siticoneButtonReportCancel.UseAdvancedRendering = true;
            siticoneButtonReportCancel.UseParticles = false;
            // 
            // siticoneLabelReportSummary
            // 
            siticoneLabelReportSummary.BackColor = Color.Transparent;
            siticoneLabelReportSummary.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            siticoneLabelReportSummary.Location = new Point(385, 9);
            siticoneLabelReportSummary.Name = "siticoneLabelReportSummary";
            siticoneLabelReportSummary.Size = new Size(70, 23);
            siticoneLabelReportSummary.TabIndex = 9;
            siticoneLabelReportSummary.Text = "Summary";
            // 
            // siticoneDGVReportSummary
            // 
            siticoneDGVReportSummary.BackColor = Color.FromArgb(45, 45, 48);
            siticoneDGVReportSummary.CellFont = new Font("Segoe UI", 9.5F);
            siticoneDGVReportSummary.DataSource = null;
            siticoneDGVReportSummary.HeaderFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            siticoneDGVReportSummary.Location = new Point(385, 35);
            siticoneDGVReportSummary.Name = "siticoneDGVReportSummary";
            siticoneDGVReportSummary.Size = new Size(507, 490);
            siticoneDGVReportSummary.TabIndex = 10;
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(892, 522);
            Controls.Add(siticoneDGVReportSummary);
            Controls.Add(siticoneLabelReportSummary);
            Controls.Add(siticoneButtonReportCancel);
            Controls.Add(siticoneButtonExportReport);
            Controls.Add(siticoneButtonReportGenerate);
            Controls.Add(siticoneDateTimePicker1);
            Controls.Add(siticoneLabelReportRangeDate);
            Controls.Add(siticoneDropdown1);
            Controls.Add(siticoneLabelReportType);
            Controls.Add(siticoneLabelReportDetails);
            Name = "ReportForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ReportForm";
            ((System.ComponentModel.ISupportInitialize)siticoneDGVReportSummary).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SiticoneNetCoreUI.SiticoneLabel siticoneLabelReportDetails;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabelReportType;
        private SiticoneNetCoreUI.SiticoneDropdown siticoneDropdown1;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabelReportRangeDate;
        private SiticoneNetCoreUI.SiticoneDateTimePicker siticoneDateTimePicker1;
        private SiticoneNetCoreUI.SiticoneButton siticoneButtonReportGenerate;
        private SiticoneNetCoreUI.SiticoneButton siticoneButtonExportReport;
        private SiticoneNetCoreUI.SiticoneButton siticoneButtonReportCancel;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabelReportSummary;
        private SiticoneNetCoreUI.SiticoneDataGridView siticoneDGVReportSummary;
    }
}