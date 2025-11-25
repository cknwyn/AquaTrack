namespace AquaTrack.Pages.Input_Forms
{
    partial class TasksListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TasksListForm));
            siticoneLabelTaskDetails = new SiticoneNetCoreUI.SiticoneLabel();
            siticoneTextAreaTask = new SiticoneNetCoreUI.SiticoneTextArea();
            siticoneLabelTask = new SiticoneNetCoreUI.SiticoneLabel();
            siticoneLabelTaskDeadline = new SiticoneNetCoreUI.SiticoneLabel();
            siticoneDTPDeadline = new SiticoneNetCoreUI.SiticoneDateTimePicker();
            siticoneButtonTaskConfirm = new SiticoneNetCoreUI.SiticoneButton();
            siticoneButtonTaskCancel = new SiticoneNetCoreUI.SiticoneButton();
            SuspendLayout();
            // 
            // siticoneLabelTaskDetails
            // 
            siticoneLabelTaskDetails.BackColor = Color.Transparent;
            siticoneLabelTaskDetails.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            siticoneLabelTaskDetails.Location = new Point(12, 9);
            siticoneLabelTaskDetails.Name = "siticoneLabelTaskDetails";
            siticoneLabelTaskDetails.Size = new Size(100, 23);
            siticoneLabelTaskDetails.TabIndex = 0;
            siticoneLabelTaskDetails.Text = "Task Details";
            // 
            // siticoneTextAreaTask
            // 
            siticoneTextAreaTask.BorderStyle = BorderStyle.None;
            siticoneTextAreaTask.Font = new Font("Century Gothic", 10F);
            siticoneTextAreaTask.Location = new Point(43, 65);
            siticoneTextAreaTask.Margin = new Padding(5);
            siticoneTextAreaTask.MinimumSize = new Size(100, 100);
            siticoneTextAreaTask.Multiline = true;
            siticoneTextAreaTask.Name = "siticoneTextAreaTask";
            siticoneTextAreaTask.PlaceholderText = "Write your task here.";
            siticoneTextAreaTask.ScrollBars = ScrollBars.Vertical;
            siticoneTextAreaTask.Size = new Size(355, 172);
            siticoneTextAreaTask.TabIndex = 1;
            // 
            // siticoneLabelTask
            // 
            siticoneLabelTask.BackColor = Color.Transparent;
            siticoneLabelTask.Font = new Font("Segoe UI", 10F);
            siticoneLabelTask.Location = new Point(43, 37);
            siticoneLabelTask.Name = "siticoneLabelTask";
            siticoneLabelTask.Size = new Size(100, 23);
            siticoneLabelTask.TabIndex = 2;
            siticoneLabelTask.Text = "Task";
            // 
            // siticoneLabelTaskDeadline
            // 
            siticoneLabelTaskDeadline.BackColor = Color.Transparent;
            siticoneLabelTaskDeadline.Font = new Font("Segoe UI", 10F);
            siticoneLabelTaskDeadline.Location = new Point(43, 259);
            siticoneLabelTaskDeadline.Name = "siticoneLabelTaskDeadline";
            siticoneLabelTaskDeadline.Size = new Size(100, 23);
            siticoneLabelTaskDeadline.TabIndex = 3;
            siticoneLabelTaskDeadline.Text = "Deadline";
            // 
            // siticoneDTPDeadline
            // 
            siticoneDTPDeadline.AutoScaleFonts = true;
            siticoneDTPDeadline.BackColor = Color.Transparent;
            siticoneDTPDeadline.BaseCalendarFormSize = new Size(535, 460);
            siticoneDTPDeadline.BorderColor = Color.Gray;
            siticoneDTPDeadline.BorderWidth = 2;
            siticoneDTPDeadline.BottomLeftBorderRadius = 0;
            siticoneDTPDeadline.BottomRightBorderRadius = 0;
            siticoneDTPDeadline.CalendarBackgroundColor = Color.White;
            siticoneDTPDeadline.CalendarChevronColor = Color.Gray;
            siticoneDTPDeadline.CalendarChevronHoverColor = Color.Blue;
            siticoneDTPDeadline.CalendarDayButtonBackColor = Color.White;
            siticoneDTPDeadline.CalendarDayButtonForeColor = Color.Black;
            siticoneDTPDeadline.CalendarDayHeaderBackColor = Color.White;
            siticoneDTPDeadline.CalendarDayHeaderForeColor = Color.FromArgb(100, 100, 100);
            siticoneDTPDeadline.CalendarDayLabelFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            siticoneDTPDeadline.CalendarDisabledDateBackColor = Color.LightGray;
            siticoneDTPDeadline.CalendarDisabledDateForeColor = Color.DarkGray;
            siticoneDTPDeadline.CalendarFormAnimationSpeed = 15;
            siticoneDTPDeadline.CalendarFormAnimationStep = 0.08D;
            siticoneDTPDeadline.CalendarFormBackColor = Color.White;
            siticoneDTPDeadline.CalendarFormBorderColor = Color.FromArgb(220, 220, 220);
            siticoneDTPDeadline.CalendarFormBorderWidth = 2;
            siticoneDTPDeadline.CalendarFormCornerRadius = 2;
            siticoneDTPDeadline.CalendarFormFadeOutStep = 0.1D;
            siticoneDTPDeadline.CalendarFormHeight = 460;
            siticoneDTPDeadline.CalendarFormShadowColor = Color.FromArgb(50, 0, 0, 0);
            siticoneDTPDeadline.CalendarFormShadowDepth = 5;
            siticoneDTPDeadline.CalendarFormWidth = 535;
            siticoneDTPDeadline.CalendarGridMargin = new Padding(8);
            siticoneDTPDeadline.CalendarGridPadding = new Padding(5);
            siticoneDTPDeadline.CalendarLockedDateBackColor = Color.LightGray;
            siticoneDTPDeadline.CalendarLockedDateForeColor = Color.DarkGray;
            siticoneDTPDeadline.CalendarLockedDates = (List<DateTime>)resources.GetObject("siticoneDTPDeadline.CalendarLockedDates");
            siticoneDTPDeadline.CalendarMargin = 5;
            siticoneDTPDeadline.CalendarMaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            siticoneDTPDeadline.CalendarMaxYear = 2125;
            siticoneDTPDeadline.CalendarMinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            siticoneDTPDeadline.CalendarMinYear = 1925;
            siticoneDTPDeadline.CalendarRangeDateBackColor = Color.LightBlue;
            siticoneDTPDeadline.CalendarRangeEndDateBackColor = Color.DodgerBlue;
            siticoneDTPDeadline.CalendarRangeSelectedForeColor = Color.Black;
            siticoneDTPDeadline.CalendarRangeStartDateBackColor = Color.DodgerBlue;
            siticoneDTPDeadline.CalendarSelectedDateBackColor = Color.Black;
            siticoneDTPDeadline.CalendarSelectedDateForeColor = Color.White;
            siticoneDTPDeadline.CalendarSelectionMode = SiticoneNetCoreUI.SelectionMode.Single;
            siticoneDTPDeadline.CalendarTodayBackColor = Color.White;
            siticoneDTPDeadline.CalendarTodayForeColor = Color.Black;
            siticoneDTPDeadline.CalendarYearPickerHeight = 10;
            siticoneDTPDeadline.CanBeep = true;
            siticoneDTPDeadline.CanShake = true;
            siticoneDTPDeadline.ChevronColor = Color.Gray;
            siticoneDTPDeadline.ChevronHoverBackColor = Color.FromArgb(220, 225, 245);
            siticoneDTPDeadline.ChevronHoverColor = Color.Black;
            siticoneDTPDeadline.ChevronPanelBorderRadius = 0;
            siticoneDTPDeadline.ChevronPanelHeight = 32;
            siticoneDTPDeadline.ChevronPenThickness = 1.8F;
            siticoneDTPDeadline.ChevronRightMargin = 18;
            siticoneDTPDeadline.ChevronSize = new Size(9, 14);
            siticoneDTPDeadline.ChevronStep = 15F;
            siticoneDTPDeadline.ChevronTimerInterval = 15;
            siticoneDTPDeadline.ClearIconColor = Color.Gray;
            siticoneDTPDeadline.ClearIconHoverColor = Color.Red;
            siticoneDTPDeadline.ClearIconRightMargin = 48;
            siticoneDTPDeadline.ClearIconSize = 11;
            siticoneDTPDeadline.ContainerPanelMargin = new Padding(5);
            siticoneDTPDeadline.ContainerPanelPadding = new Padding(0);
            siticoneDTPDeadline.CustomDateFormat = "d";
            siticoneDTPDeadline.CustomDateFormatter = null;
            siticoneDTPDeadline.DateFormat = SiticoneNetCoreUI.DateFormat.LongDate;
            siticoneDTPDeadline.DayButtonBorderRadius = 0;
            siticoneDTPDeadline.DayButtonClickBackColor = Color.FromArgb(220, 230, 250);
            siticoneDTPDeadline.DayButtonFont = new Font("Segoe UI", 10.5F);
            siticoneDTPDeadline.DayButtonHoverBackColor = Color.FromArgb(235, 240, 255);
            siticoneDTPDeadline.DayButtonHoverForeColor = Color.Black;
            siticoneDTPDeadline.DayButtonMargin = new Padding(3);
            siticoneDTPDeadline.DayButtonRowHeight = 16.66F;
            siticoneDTPDeadline.DayHeaderFont = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            siticoneDTPDeadline.DayHeaderForeColor = Color.FromArgb(100, 100, 100);
            siticoneDTPDeadline.DayHeaderMargin = new Padding(1, 1, 1, 8);
            siticoneDTPDeadline.DayHeaderRowHeight = 30F;
            siticoneDTPDeadline.DisabledDayFont = new Font("Segoe UI", 10F, FontStyle.Italic);
            siticoneDTPDeadline.DropdownBackColor = Color.White;
            siticoneDTPDeadline.DropdownFont = new Font("Segoe UI", 11F);
            siticoneDTPDeadline.DropdownHeight = 250;
            siticoneDTPDeadline.FillColor = Color.White;
            siticoneDTPDeadline.FirstDayOfWeek = DayOfWeek.Sunday;
            siticoneDTPDeadline.Font = new Font("Segoe UI", 10F);
            siticoneDTPDeadline.ForeColor = Color.DimGray;
            siticoneDTPDeadline.GradientEndColor = Color.Gray;
            siticoneDTPDeadline.GradientStartColor = Color.White;
            siticoneDTPDeadline.HighlightWeekends = true;
            siticoneDTPDeadline.IconSize = 16;
            siticoneDTPDeadline.IsReadonly = false;
            siticoneDTPDeadline.Location = new Point(43, 285);
            siticoneDTPDeadline.LockedDates = (List<DateTime>)resources.GetObject("siticoneDTPDeadline.LockedDates");
            siticoneDTPDeadline.MakeRadial = false;
            siticoneDTPDeadline.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            siticoneDTPDeadline.MaxFontScale = 1.8F;
            siticoneDTPDeadline.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            siticoneDTPDeadline.MinFontScale = 0.4F;
            siticoneDTPDeadline.MinimumFormSize = new Size(150, 150);
            siticoneDTPDeadline.MonthChevronPanelMargin = new Padding(4, 17, 4, 0);
            siticoneDTPDeadline.MonthChevronSpacing = 5;
            siticoneDTPDeadline.MonthComboBoxMargin = new Padding(0, 17, 5, 0);
            siticoneDTPDeadline.MonthComboBoxSize = new Size(130, 30);
            siticoneDTPDeadline.Name = "siticoneDTPDeadline";
            siticoneDTPDeadline.NavigationFlowPadding = new Padding(12, 0, 12, 0);
            siticoneDTPDeadline.NavigationPanelBackColor = Color.FromArgb(245, 245, 250);
            siticoneDTPDeadline.NavigationPanelHeight = 65;
            siticoneDTPDeadline.NextMonthPanelWidth = 34;
            siticoneDTPDeadline.NextYearPanelWidth = 40;
            siticoneDTPDeadline.PlaceholderText = "Select a date, dates or range...";
            siticoneDTPDeadline.PrevMonthPanelWidth = 34;
            siticoneDTPDeadline.PrevYearPanelWidth = 40;
            siticoneDTPDeadline.RangeStartEndCornerRadius = 0;
            siticoneDTPDeadline.ReadonlyBorderColor = Color.Gray;
            siticoneDTPDeadline.ReadonlyFillColor = Color.LightGray;
            siticoneDTPDeadline.ReadOnlyForeColor = Color.DarkGray;
            siticoneDTPDeadline.ReadonlyPlaceHolderColor = Color.DarkGray;
            siticoneDTPDeadline.SelectedDate = null;
            siticoneDTPDeadline.SelectedDateBorderColor = Color.Black;
            siticoneDTPDeadline.SelectedDateBorderThickness = 1F;
            siticoneDTPDeadline.SelectedDates = (List<DateTime>)resources.GetObject("siticoneDTPDeadline.SelectedDates");
            siticoneDTPDeadline.SelectionMode = SiticoneNetCoreUI.SelectionMode.Single;
            siticoneDTPDeadline.ShakeAmplitude = 4;
            siticoneDTPDeadline.ShakeTimerInterval = 30;
            siticoneDTPDeadline.ShakeTotalShakes = 8;
            siticoneDTPDeadline.ShowClearButton = true;
            siticoneDTPDeadline.ShowMonthYearNavigation = true;
            siticoneDTPDeadline.ShowTodayButton = true;
            siticoneDTPDeadline.Size = new Size(355, 45);
            siticoneDTPDeadline.TabIndex = 4;
            siticoneDTPDeadline.TodayBorderColor = Color.Black;
            siticoneDTPDeadline.TodayBorderThickness = 2F;
            siticoneDTPDeadline.TodayButtonBackColor = Color.Black;
            siticoneDTPDeadline.TodayButtonBorderRadius = 0;
            siticoneDTPDeadline.TodayButtonClickBackColor = Color.Black;
            siticoneDTPDeadline.TodayButtonFont = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            siticoneDTPDeadline.TodayButtonForeColor = Color.White;
            siticoneDTPDeadline.TodayButtonHoverBackColor = Color.FromArgb(64, 64, 64);
            siticoneDTPDeadline.TodayButtonMargin = new Padding(0, 17, 15, 0);
            siticoneDTPDeadline.TodayButtonSize = new Size(70, 35);
            siticoneDTPDeadline.TodayButtonText = "Today";
            siticoneDTPDeadline.TodayTextColor = Color.Black;
            siticoneDTPDeadline.TodayTextFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            siticoneDTPDeadline.TopLeftBorderRadius = 0;
            siticoneDTPDeadline.TopRightBorderRadius = 0;
            siticoneDTPDeadline.UseCalendarFormAnimation = true;
            siticoneDTPDeadline.UseCalendarFormShadow = true;
            siticoneDTPDeadline.UseChevronAnimation = true;
            siticoneDTPDeadline.UseGradientFill = false;
            siticoneDTPDeadline.Value = null;
            siticoneDTPDeadline.WeekendDayBackColor = Color.FromArgb(250, 250, 250);
            siticoneDTPDeadline.WeekendDayForeColor = Color.FromArgb(180, 0, 0);
            siticoneDTPDeadline.YearChevronPanelMargin = new Padding(4, 17, 4, 0);
            siticoneDTPDeadline.YearChevronSpacing = 1;
            siticoneDTPDeadline.YearComboBoxMargin = new Padding(5, 17, 0, 0);
            siticoneDTPDeadline.YearComboBoxSize = new Size(90, 30);
            // 
            // siticoneButtonTaskConfirm
            // 
            siticoneButtonTaskConfirm.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            siticoneButtonTaskConfirm.AccessibleName = "Confirm";
            siticoneButtonTaskConfirm.AutoSizeBasedOnText = false;
            siticoneButtonTaskConfirm.BackColor = Color.Transparent;
            siticoneButtonTaskConfirm.BadgeBackColor = Color.Black;
            siticoneButtonTaskConfirm.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            siticoneButtonTaskConfirm.BadgeValue = 0;
            siticoneButtonTaskConfirm.BadgeValueForeColor = Color.White;
            siticoneButtonTaskConfirm.BorderColor = Color.FromArgb(213, 216, 220);
            siticoneButtonTaskConfirm.BorderWidth = 1;
            siticoneButtonTaskConfirm.ButtonBackColor = Color.FromArgb(192, 255, 192);
            siticoneButtonTaskConfirm.ButtonImage = null;
            siticoneButtonTaskConfirm.ButtonTextLeftPadding = 0;
            siticoneButtonTaskConfirm.CanBeep = true;
            siticoneButtonTaskConfirm.CanGlow = false;
            siticoneButtonTaskConfirm.CanShake = true;
            siticoneButtonTaskConfirm.ContextMenuStripEx = null;
            siticoneButtonTaskConfirm.CornerRadiusBottomLeft = 6;
            siticoneButtonTaskConfirm.CornerRadiusBottomRight = 6;
            siticoneButtonTaskConfirm.CornerRadiusTopLeft = 6;
            siticoneButtonTaskConfirm.CornerRadiusTopRight = 6;
            siticoneButtonTaskConfirm.CustomCursor = Cursors.Default;
            siticoneButtonTaskConfirm.DisabledTextColor = Color.FromArgb(150, 150, 150);
            siticoneButtonTaskConfirm.EnableLongPress = false;
            siticoneButtonTaskConfirm.EnableRippleEffect = true;
            siticoneButtonTaskConfirm.EnableShadow = false;
            siticoneButtonTaskConfirm.EnableTextWrapping = false;
            siticoneButtonTaskConfirm.Font = new Font("Segoe UI Semibold", 10.2F);
            siticoneButtonTaskConfirm.GlowColor = Color.FromArgb(100, 255, 255, 255);
            siticoneButtonTaskConfirm.GlowIntensity = 100;
            siticoneButtonTaskConfirm.GlowRadius = 20F;
            siticoneButtonTaskConfirm.GradientBackground = false;
            siticoneButtonTaskConfirm.GradientColor = Color.FromArgb(0, 227, 64);
            siticoneButtonTaskConfirm.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            siticoneButtonTaskConfirm.HintText = null;
            siticoneButtonTaskConfirm.HoverBackColor = Color.FromArgb(240, 240, 240);
            siticoneButtonTaskConfirm.HoverFontStyle = FontStyle.Regular;
            siticoneButtonTaskConfirm.HoverTextColor = Color.FromArgb(0, 0, 0);
            siticoneButtonTaskConfirm.HoverTransitionDuration = 250;
            siticoneButtonTaskConfirm.ImageAlign = ContentAlignment.MiddleLeft;
            siticoneButtonTaskConfirm.ImagePadding = 5;
            siticoneButtonTaskConfirm.ImageSize = new Size(16, 16);
            siticoneButtonTaskConfirm.IsRadial = false;
            siticoneButtonTaskConfirm.IsReadOnly = false;
            siticoneButtonTaskConfirm.IsToggleButton = false;
            siticoneButtonTaskConfirm.IsToggled = false;
            siticoneButtonTaskConfirm.Location = new Point(43, 353);
            siticoneButtonTaskConfirm.LongPressDurationMS = 1000;
            siticoneButtonTaskConfirm.Name = "siticoneButtonTaskConfirm";
            siticoneButtonTaskConfirm.NormalFontStyle = FontStyle.Regular;
            siticoneButtonTaskConfirm.ParticleColor = Color.FromArgb(200, 200, 200);
            siticoneButtonTaskConfirm.ParticleCount = 15;
            siticoneButtonTaskConfirm.PressAnimationScale = 0.97F;
            siticoneButtonTaskConfirm.PressedBackColor = Color.FromArgb(225, 227, 230);
            siticoneButtonTaskConfirm.PressedFontStyle = FontStyle.Regular;
            siticoneButtonTaskConfirm.PressTransitionDuration = 150;
            siticoneButtonTaskConfirm.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            siticoneButtonTaskConfirm.RippleColor = Color.FromArgb(0, 0, 0);
            siticoneButtonTaskConfirm.RippleRadiusMultiplier = 0.6F;
            siticoneButtonTaskConfirm.ShadowBlur = 5;
            siticoneButtonTaskConfirm.ShadowColor = Color.FromArgb(30, 0, 0, 0);
            siticoneButtonTaskConfirm.ShadowOffset = new Point(0, 2);
            siticoneButtonTaskConfirm.ShakeDuration = 500;
            siticoneButtonTaskConfirm.ShakeIntensity = 5;
            siticoneButtonTaskConfirm.Size = new Size(355, 50);
            siticoneButtonTaskConfirm.TabIndex = 5;
            siticoneButtonTaskConfirm.Text = "Confirm";
            siticoneButtonTaskConfirm.TextAlign = ContentAlignment.MiddleCenter;
            siticoneButtonTaskConfirm.TextColor = Color.FromArgb(0, 0, 0);
            siticoneButtonTaskConfirm.TooltipText = null;
            siticoneButtonTaskConfirm.UseAdvancedRendering = true;
            siticoneButtonTaskConfirm.UseParticles = false;
            siticoneButtonTaskConfirm.Click += siticoneButtonTaskConfirm_Click;
            // 
            // siticoneButtonTaskCancel
            // 
            siticoneButtonTaskCancel.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            siticoneButtonTaskCancel.AccessibleName = "Cancel";
            siticoneButtonTaskCancel.AutoSizeBasedOnText = false;
            siticoneButtonTaskCancel.BackColor = Color.Transparent;
            siticoneButtonTaskCancel.BadgeBackColor = Color.Black;
            siticoneButtonTaskCancel.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            siticoneButtonTaskCancel.BadgeValue = 0;
            siticoneButtonTaskCancel.BadgeValueForeColor = Color.White;
            siticoneButtonTaskCancel.BorderColor = Color.FromArgb(213, 216, 220);
            siticoneButtonTaskCancel.BorderWidth = 1;
            siticoneButtonTaskCancel.ButtonBackColor = Color.FromArgb(255, 192, 192);
            siticoneButtonTaskCancel.ButtonImage = null;
            siticoneButtonTaskCancel.ButtonTextLeftPadding = 0;
            siticoneButtonTaskCancel.CanBeep = true;
            siticoneButtonTaskCancel.CanGlow = false;
            siticoneButtonTaskCancel.CanShake = true;
            siticoneButtonTaskCancel.ContextMenuStripEx = null;
            siticoneButtonTaskCancel.CornerRadiusBottomLeft = 6;
            siticoneButtonTaskCancel.CornerRadiusBottomRight = 6;
            siticoneButtonTaskCancel.CornerRadiusTopLeft = 6;
            siticoneButtonTaskCancel.CornerRadiusTopRight = 6;
            siticoneButtonTaskCancel.CustomCursor = Cursors.Default;
            siticoneButtonTaskCancel.DisabledTextColor = Color.FromArgb(150, 150, 150);
            siticoneButtonTaskCancel.EnableLongPress = false;
            siticoneButtonTaskCancel.EnableRippleEffect = true;
            siticoneButtonTaskCancel.EnableShadow = false;
            siticoneButtonTaskCancel.EnableTextWrapping = false;
            siticoneButtonTaskCancel.Font = new Font("Segoe UI Semibold", 10.2F);
            siticoneButtonTaskCancel.GlowColor = Color.FromArgb(100, 255, 255, 255);
            siticoneButtonTaskCancel.GlowIntensity = 100;
            siticoneButtonTaskCancel.GlowRadius = 20F;
            siticoneButtonTaskCancel.GradientBackground = false;
            siticoneButtonTaskCancel.GradientColor = Color.FromArgb(0, 227, 64);
            siticoneButtonTaskCancel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            siticoneButtonTaskCancel.HintText = null;
            siticoneButtonTaskCancel.HoverBackColor = Color.FromArgb(240, 240, 240);
            siticoneButtonTaskCancel.HoverFontStyle = FontStyle.Regular;
            siticoneButtonTaskCancel.HoverTextColor = Color.FromArgb(0, 0, 0);
            siticoneButtonTaskCancel.HoverTransitionDuration = 250;
            siticoneButtonTaskCancel.ImageAlign = ContentAlignment.MiddleLeft;
            siticoneButtonTaskCancel.ImagePadding = 5;
            siticoneButtonTaskCancel.ImageSize = new Size(16, 16);
            siticoneButtonTaskCancel.IsRadial = false;
            siticoneButtonTaskCancel.IsReadOnly = false;
            siticoneButtonTaskCancel.IsToggleButton = false;
            siticoneButtonTaskCancel.IsToggled = false;
            siticoneButtonTaskCancel.Location = new Point(43, 409);
            siticoneButtonTaskCancel.LongPressDurationMS = 1000;
            siticoneButtonTaskCancel.Name = "siticoneButtonTaskCancel";
            siticoneButtonTaskCancel.NormalFontStyle = FontStyle.Regular;
            siticoneButtonTaskCancel.ParticleColor = Color.FromArgb(200, 200, 200);
            siticoneButtonTaskCancel.ParticleCount = 15;
            siticoneButtonTaskCancel.PressAnimationScale = 0.97F;
            siticoneButtonTaskCancel.PressedBackColor = Color.FromArgb(225, 227, 230);
            siticoneButtonTaskCancel.PressedFontStyle = FontStyle.Regular;
            siticoneButtonTaskCancel.PressTransitionDuration = 150;
            siticoneButtonTaskCancel.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            siticoneButtonTaskCancel.RippleColor = Color.FromArgb(0, 0, 0);
            siticoneButtonTaskCancel.RippleRadiusMultiplier = 0.6F;
            siticoneButtonTaskCancel.ShadowBlur = 5;
            siticoneButtonTaskCancel.ShadowColor = Color.FromArgb(30, 0, 0, 0);
            siticoneButtonTaskCancel.ShadowOffset = new Point(0, 2);
            siticoneButtonTaskCancel.ShakeDuration = 500;
            siticoneButtonTaskCancel.ShakeIntensity = 5;
            siticoneButtonTaskCancel.Size = new Size(355, 50);
            siticoneButtonTaskCancel.TabIndex = 6;
            siticoneButtonTaskCancel.Text = "Cancel";
            siticoneButtonTaskCancel.TextAlign = ContentAlignment.MiddleCenter;
            siticoneButtonTaskCancel.TextColor = Color.FromArgb(0, 0, 0);
            siticoneButtonTaskCancel.TooltipText = null;
            siticoneButtonTaskCancel.UseAdvancedRendering = true;
            siticoneButtonTaskCancel.UseParticles = false;
            // 
            // TasksListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(435, 494);
            Controls.Add(siticoneButtonTaskCancel);
            Controls.Add(siticoneButtonTaskConfirm);
            Controls.Add(siticoneDTPDeadline);
            Controls.Add(siticoneLabelTaskDeadline);
            Controls.Add(siticoneLabelTask);
            Controls.Add(siticoneTextAreaTask);
            Controls.Add(siticoneLabelTaskDetails);
            Name = "TasksListForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TasksListForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SiticoneNetCoreUI.SiticoneLabel siticoneLabelTaskDetails;
        private SiticoneNetCoreUI.SiticoneTextArea siticoneTextAreaTask;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabelTask;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabelTaskDeadline;
        private SiticoneNetCoreUI.SiticoneDateTimePicker siticoneDTPDeadline;
        private SiticoneNetCoreUI.SiticoneButton siticoneButtonTaskConfirm;
        private SiticoneNetCoreUI.SiticoneButton siticoneButtonTaskCancel;
    }
}