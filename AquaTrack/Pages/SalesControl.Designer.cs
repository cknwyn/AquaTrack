namespace AquaTrack.Pages
{
    partial class SalesControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesControl));
            siticoneButtonTextboxSearchSales = new SiticoneNetCoreUI.SiticoneButtonTextbox();
            siticoneDataGridViewSale = new SiticoneNetCoreUI.SiticoneDataGridView();
            siticoneDataGridViewSaleItems = new SiticoneNetCoreUI.SiticoneDataGridView();
            siticoneBtnDeleteSale = new SiticoneNetCoreUI.SiticoneButton();
            siticoneBtnEditSale = new SiticoneNetCoreUI.SiticoneButton();
            siticoneBtnAddSale = new SiticoneNetCoreUI.SiticoneButton();
            ((System.ComponentModel.ISupportInitialize)siticoneDataGridViewSale).BeginInit();
            ((System.ComponentModel.ISupportInitialize)siticoneDataGridViewSaleItems).BeginInit();
            SuspendLayout();
            // 
            // siticoneButtonTextboxSearchSales
            // 
            siticoneButtonTextboxSearchSales.BackColor = Color.Transparent;
            siticoneButtonTextboxSearchSales.BackgroundColor = Color.FromArgb(250, 250, 250);
            siticoneButtonTextboxSearchSales.BorderColor = Color.FromArgb(200, 200, 200);
            siticoneButtonTextboxSearchSales.BorderWidth = 1;
            siticoneButtonTextboxSearchSales.BottomLeftCornerRadius = 20;
            siticoneButtonTextboxSearchSales.BottomRightCornerRadius = 20;
            siticoneButtonTextboxSearchSales.ButtonColor = Color.FromArgb(230, 230, 230);
            siticoneButtonTextboxSearchSales.ButtonCornerRadius = 30;
            siticoneButtonTextboxSearchSales.ButtonHoverColor = Color.FromArgb(210, 210, 210);
            siticoneButtonTextboxSearchSales.ButtonImageHover = null;
            siticoneButtonTextboxSearchSales.ButtonImageIdle = Properties.Resources.ico_search;
            siticoneButtonTextboxSearchSales.ButtonImagePress = null;
            siticoneButtonTextboxSearchSales.ButtonPlaceholderColor = Color.Black;
            siticoneButtonTextboxSearchSales.ButtonPlaceholderFont = new Font("Segoe UI", 12F, FontStyle.Bold);
            siticoneButtonTextboxSearchSales.ButtonPressColor = Color.FromArgb(224, 224, 224);
            siticoneButtonTextboxSearchSales.FocusBorderColor = Color.FromArgb(0, 123, 255);
            siticoneButtonTextboxSearchSales.FocusImage = null;
            siticoneButtonTextboxSearchSales.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            siticoneButtonTextboxSearchSales.ForeColor = Color.FromArgb(30, 30, 30);
            siticoneButtonTextboxSearchSales.HoverBorderColor = Color.Gray;
            siticoneButtonTextboxSearchSales.HoverImage = null;
            siticoneButtonTextboxSearchSales.IdleImage = null;
            siticoneButtonTextboxSearchSales.Location = new Point(1, 6);
            siticoneButtonTextboxSearchSales.Name = "siticoneButtonTextboxSearchSales";
            siticoneButtonTextboxSearchSales.PlaceholderColor = Color.FromArgb(108, 117, 125);
            siticoneButtonTextboxSearchSales.PlaceholderFocusColor = Color.FromArgb(0, 123, 255);
            siticoneButtonTextboxSearchSales.PlaceholderFont = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            siticoneButtonTextboxSearchSales.PlaceholderText = "Search...";
            siticoneButtonTextboxSearchSales.ReadOnlyColors.BackgroundColor = Color.FromArgb(245, 245, 245);
            siticoneButtonTextboxSearchSales.ReadOnlyColors.BorderColor = Color.FromArgb(200, 200, 200);
            siticoneButtonTextboxSearchSales.ReadOnlyColors.ButtonColor = Color.FromArgb(224, 224, 224);
            siticoneButtonTextboxSearchSales.ReadOnlyColors.ButtonPlaceholderColor = Color.Gray;
            siticoneButtonTextboxSearchSales.ReadOnlyColors.PlaceholderColor = Color.FromArgb(150, 150, 150);
            siticoneButtonTextboxSearchSales.ReadOnlyColors.TextColor = Color.FromArgb(100, 100, 100);
            siticoneButtonTextboxSearchSales.RippleColor = Color.White;
            siticoneButtonTextboxSearchSales.Size = new Size(260, 35);
            siticoneButtonTextboxSearchSales.TabIndex = 1;
            siticoneButtonTextboxSearchSales.TextBoxStyle = SiticoneNetCoreUI.ButtonTextboxStyle.Material;
            siticoneButtonTextboxSearchSales.TextColor = Color.FromArgb(30, 30, 30);
            siticoneButtonTextboxSearchSales.TextContent = "";
            siticoneButtonTextboxSearchSales.TextLeftMargin = 0;
            siticoneButtonTextboxSearchSales.TopLeftCornerRadius = 20;
            siticoneButtonTextboxSearchSales.TopRightCornerRadius = 20;
            siticoneButtonTextboxSearchSales.ValidationEnabled = false;
            siticoneButtonTextboxSearchSales.ButtonClick += siticoneButtonTextboxSearchSales_ButtonClick;
            // 
            // siticoneDataGridViewSale
            // 
            siticoneDataGridViewSale.AutoScroll = true;
            siticoneDataGridViewSale.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            siticoneDataGridViewSale.BackColor = Color.FromArgb(240, 248, 255);
            siticoneDataGridViewSale.CellFont = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            siticoneDataGridViewSale.GridTheme = SiticoneNetCoreUI.GridTheme.Blue;
            siticoneDataGridViewSale.HeaderFont = new Font("Verdana", 9.75F, FontStyle.Bold);
            siticoneDataGridViewSale.Location = new Point(3, 47);
            siticoneDataGridViewSale.Name = "siticoneDataGridViewSale";
            siticoneDataGridViewSale.ShowSampleData = true;
            siticoneDataGridViewSale.Size = new Size(488, 428);
            siticoneDataGridViewSale.TabIndex = 2;
            siticoneDataGridViewSale.Load += SalesControl_Load;
            // 
            // siticoneDataGridViewSaleItems
            // 
            siticoneDataGridViewSaleItems.AutoScroll = true;
            siticoneDataGridViewSaleItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            siticoneDataGridViewSaleItems.BackColor = Color.FromArgb(240, 248, 255);
            siticoneDataGridViewSaleItems.CellFont = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            siticoneDataGridViewSaleItems.GridTheme = SiticoneNetCoreUI.GridTheme.Blue;
            siticoneDataGridViewSaleItems.HeaderFont = new Font("Verdana", 9.75F, FontStyle.Bold);
            siticoneDataGridViewSaleItems.Location = new Point(507, 47);
            siticoneDataGridViewSaleItems.Name = "siticoneDataGridViewSaleItems";
            siticoneDataGridViewSaleItems.ShowSampleData = true;
            siticoneDataGridViewSaleItems.Size = new Size(505, 428);
            siticoneDataGridViewSaleItems.TabIndex = 3;
            // 
            // siticoneBtnDeleteSale
            // 
            siticoneBtnDeleteSale.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            siticoneBtnDeleteSale.AccessibleName = "Delete";
            siticoneBtnDeleteSale.AutoSizeBasedOnText = false;
            siticoneBtnDeleteSale.BackColor = Color.Transparent;
            siticoneBtnDeleteSale.BadgeBackColor = Color.Black;
            siticoneBtnDeleteSale.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            siticoneBtnDeleteSale.BadgeValue = 0;
            siticoneBtnDeleteSale.BadgeValueForeColor = Color.White;
            siticoneBtnDeleteSale.BorderColor = Color.FromArgb(213, 216, 220);
            siticoneBtnDeleteSale.BorderWidth = 1;
            siticoneBtnDeleteSale.ButtonBackColor = Color.FromArgb(255, 192, 192);
            siticoneBtnDeleteSale.ButtonImage = null;
            siticoneBtnDeleteSale.ButtonTextLeftPadding = 0;
            siticoneBtnDeleteSale.CanBeep = true;
            siticoneBtnDeleteSale.CanGlow = false;
            siticoneBtnDeleteSale.CanShake = true;
            siticoneBtnDeleteSale.ContextMenuStripEx = null;
            siticoneBtnDeleteSale.CornerRadiusBottomLeft = 6;
            siticoneBtnDeleteSale.CornerRadiusBottomRight = 6;
            siticoneBtnDeleteSale.CornerRadiusTopLeft = 6;
            siticoneBtnDeleteSale.CornerRadiusTopRight = 6;
            siticoneBtnDeleteSale.CustomCursor = Cursors.Default;
            siticoneBtnDeleteSale.DisabledTextColor = Color.FromArgb(150, 150, 150);
            siticoneBtnDeleteSale.EnableLongPress = false;
            siticoneBtnDeleteSale.EnableRippleEffect = true;
            siticoneBtnDeleteSale.EnableShadow = false;
            siticoneBtnDeleteSale.EnableTextWrapping = false;
            siticoneBtnDeleteSale.Font = new Font("Segoe UI Semibold", 10.2F);
            siticoneBtnDeleteSale.GlowColor = Color.FromArgb(100, 255, 255, 255);
            siticoneBtnDeleteSale.GlowIntensity = 100;
            siticoneBtnDeleteSale.GlowRadius = 20F;
            siticoneBtnDeleteSale.GradientBackground = false;
            siticoneBtnDeleteSale.GradientColor = Color.FromArgb(0, 227, 64);
            siticoneBtnDeleteSale.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            siticoneBtnDeleteSale.HintText = null;
            siticoneBtnDeleteSale.HoverBackColor = Color.FromArgb(240, 240, 240);
            siticoneBtnDeleteSale.HoverFontStyle = FontStyle.Regular;
            siticoneBtnDeleteSale.HoverTextColor = Color.FromArgb(0, 0, 0);
            siticoneBtnDeleteSale.HoverTransitionDuration = 250;
            siticoneBtnDeleteSale.ImageAlign = ContentAlignment.MiddleLeft;
            siticoneBtnDeleteSale.ImagePadding = 5;
            siticoneBtnDeleteSale.ImageSize = new Size(16, 16);
            siticoneBtnDeleteSale.IsRadial = false;
            siticoneBtnDeleteSale.IsReadOnly = false;
            siticoneBtnDeleteSale.IsToggleButton = false;
            siticoneBtnDeleteSale.IsToggled = false;
            siticoneBtnDeleteSale.Location = new Point(863, 3);
            siticoneBtnDeleteSale.LongPressDurationMS = 1000;
            siticoneBtnDeleteSale.Name = "siticoneBtnDeleteSale";
            siticoneBtnDeleteSale.NormalFontStyle = FontStyle.Regular;
            siticoneBtnDeleteSale.ParticleColor = Color.FromArgb(200, 200, 200);
            siticoneBtnDeleteSale.ParticleCount = 15;
            siticoneBtnDeleteSale.PressAnimationScale = 0.97F;
            siticoneBtnDeleteSale.PressedBackColor = Color.FromArgb(225, 227, 230);
            siticoneBtnDeleteSale.PressedFontStyle = FontStyle.Regular;
            siticoneBtnDeleteSale.PressTransitionDuration = 150;
            siticoneBtnDeleteSale.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            siticoneBtnDeleteSale.RippleColor = Color.FromArgb(0, 0, 0);
            siticoneBtnDeleteSale.RippleRadiusMultiplier = 0.6F;
            siticoneBtnDeleteSale.ShadowBlur = 5;
            siticoneBtnDeleteSale.ShadowColor = Color.FromArgb(30, 0, 0, 0);
            siticoneBtnDeleteSale.ShadowOffset = new Point(0, 2);
            siticoneBtnDeleteSale.ShakeDuration = 500;
            siticoneBtnDeleteSale.ShakeIntensity = 5;
            siticoneBtnDeleteSale.Size = new Size(164, 38);
            siticoneBtnDeleteSale.TabIndex = 7;
            siticoneBtnDeleteSale.Text = "Delete";
            siticoneBtnDeleteSale.TextAlign = ContentAlignment.MiddleCenter;
            siticoneBtnDeleteSale.TextColor = Color.FromArgb(0, 0, 0);
            siticoneBtnDeleteSale.TooltipText = null;
            siticoneBtnDeleteSale.UseAdvancedRendering = true;
            siticoneBtnDeleteSale.UseParticles = false;
            siticoneBtnDeleteSale.Click += siticoneBtnDeleteSale_Click;
            // 
            // siticoneBtnEditSale
            // 
            siticoneBtnEditSale.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            siticoneBtnEditSale.AccessibleName = "Edit";
            siticoneBtnEditSale.AutoSizeBasedOnText = false;
            siticoneBtnEditSale.BackColor = Color.Transparent;
            siticoneBtnEditSale.BadgeBackColor = Color.Black;
            siticoneBtnEditSale.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            siticoneBtnEditSale.BadgeValue = 0;
            siticoneBtnEditSale.BadgeValueForeColor = Color.White;
            siticoneBtnEditSale.BorderColor = Color.FromArgb(213, 216, 220);
            siticoneBtnEditSale.BorderWidth = 1;
            siticoneBtnEditSale.ButtonBackColor = Color.FromArgb(255, 255, 192);
            siticoneBtnEditSale.ButtonImage = null;
            siticoneBtnEditSale.ButtonTextLeftPadding = 0;
            siticoneBtnEditSale.CanBeep = true;
            siticoneBtnEditSale.CanGlow = false;
            siticoneBtnEditSale.CanShake = true;
            siticoneBtnEditSale.ContextMenuStripEx = null;
            siticoneBtnEditSale.CornerRadiusBottomLeft = 6;
            siticoneBtnEditSale.CornerRadiusBottomRight = 6;
            siticoneBtnEditSale.CornerRadiusTopLeft = 6;
            siticoneBtnEditSale.CornerRadiusTopRight = 6;
            siticoneBtnEditSale.CustomCursor = Cursors.Default;
            siticoneBtnEditSale.DisabledTextColor = Color.FromArgb(150, 150, 150);
            siticoneBtnEditSale.EnableLongPress = false;
            siticoneBtnEditSale.EnableRippleEffect = true;
            siticoneBtnEditSale.EnableShadow = false;
            siticoneBtnEditSale.EnableTextWrapping = false;
            siticoneBtnEditSale.Font = new Font("Segoe UI Semibold", 10.2F);
            siticoneBtnEditSale.GlowColor = Color.FromArgb(100, 255, 255, 255);
            siticoneBtnEditSale.GlowIntensity = 100;
            siticoneBtnEditSale.GlowRadius = 20F;
            siticoneBtnEditSale.GradientBackground = false;
            siticoneBtnEditSale.GradientColor = Color.FromArgb(0, 227, 64);
            siticoneBtnEditSale.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            siticoneBtnEditSale.HintText = null;
            siticoneBtnEditSale.HoverBackColor = Color.FromArgb(240, 240, 240);
            siticoneBtnEditSale.HoverFontStyle = FontStyle.Regular;
            siticoneBtnEditSale.HoverTextColor = Color.FromArgb(0, 0, 0);
            siticoneBtnEditSale.HoverTransitionDuration = 250;
            siticoneBtnEditSale.ImageAlign = ContentAlignment.MiddleLeft;
            siticoneBtnEditSale.ImagePadding = 5;
            siticoneBtnEditSale.ImageSize = new Size(16, 16);
            siticoneBtnEditSale.IsRadial = false;
            siticoneBtnEditSale.IsReadOnly = false;
            siticoneBtnEditSale.IsToggleButton = false;
            siticoneBtnEditSale.IsToggled = false;
            siticoneBtnEditSale.Location = new Point(693, 3);
            siticoneBtnEditSale.LongPressDurationMS = 1000;
            siticoneBtnEditSale.Name = "siticoneBtnEditSale";
            siticoneBtnEditSale.NormalFontStyle = FontStyle.Regular;
            siticoneBtnEditSale.ParticleColor = Color.FromArgb(200, 200, 200);
            siticoneBtnEditSale.ParticleCount = 15;
            siticoneBtnEditSale.PressAnimationScale = 0.97F;
            siticoneBtnEditSale.PressedBackColor = Color.FromArgb(225, 227, 230);
            siticoneBtnEditSale.PressedFontStyle = FontStyle.Regular;
            siticoneBtnEditSale.PressTransitionDuration = 150;
            siticoneBtnEditSale.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            siticoneBtnEditSale.RippleColor = Color.FromArgb(0, 0, 0);
            siticoneBtnEditSale.RippleRadiusMultiplier = 0.6F;
            siticoneBtnEditSale.ShadowBlur = 5;
            siticoneBtnEditSale.ShadowColor = Color.FromArgb(30, 0, 0, 0);
            siticoneBtnEditSale.ShadowOffset = new Point(0, 2);
            siticoneBtnEditSale.ShakeDuration = 500;
            siticoneBtnEditSale.ShakeIntensity = 5;
            siticoneBtnEditSale.Size = new Size(164, 38);
            siticoneBtnEditSale.TabIndex = 6;
            siticoneBtnEditSale.Text = "Edit";
            siticoneBtnEditSale.TextAlign = ContentAlignment.MiddleCenter;
            siticoneBtnEditSale.TextColor = Color.FromArgb(0, 0, 0);
            siticoneBtnEditSale.TooltipText = null;
            siticoneBtnEditSale.UseAdvancedRendering = true;
            siticoneBtnEditSale.UseParticles = false;
            siticoneBtnEditSale.Click += siticoneBtnEditSale_Click;
            // 
            // siticoneBtnAddSale
            // 
            siticoneBtnAddSale.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            siticoneBtnAddSale.AccessibleName = "Add";
            siticoneBtnAddSale.AutoSizeBasedOnText = false;
            siticoneBtnAddSale.BackColor = Color.Transparent;
            siticoneBtnAddSale.BadgeBackColor = Color.Black;
            siticoneBtnAddSale.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            siticoneBtnAddSale.BadgeValue = 0;
            siticoneBtnAddSale.BadgeValueForeColor = Color.White;
            siticoneBtnAddSale.BorderColor = Color.FromArgb(213, 216, 220);
            siticoneBtnAddSale.BorderWidth = 1;
            siticoneBtnAddSale.ButtonBackColor = Color.FromArgb(192, 255, 192);
            siticoneBtnAddSale.ButtonImage = null;
            siticoneBtnAddSale.ButtonTextLeftPadding = 0;
            siticoneBtnAddSale.CanBeep = true;
            siticoneBtnAddSale.CanGlow = false;
            siticoneBtnAddSale.CanShake = true;
            siticoneBtnAddSale.ContextMenuStripEx = null;
            siticoneBtnAddSale.CornerRadiusBottomLeft = 6;
            siticoneBtnAddSale.CornerRadiusBottomRight = 6;
            siticoneBtnAddSale.CornerRadiusTopLeft = 6;
            siticoneBtnAddSale.CornerRadiusTopRight = 6;
            siticoneBtnAddSale.CustomCursor = Cursors.Default;
            siticoneBtnAddSale.DisabledTextColor = Color.FromArgb(150, 150, 150);
            siticoneBtnAddSale.EnableLongPress = false;
            siticoneBtnAddSale.EnableRippleEffect = true;
            siticoneBtnAddSale.EnableShadow = false;
            siticoneBtnAddSale.EnableTextWrapping = false;
            siticoneBtnAddSale.Font = new Font("Segoe UI Semibold", 10.2F);
            siticoneBtnAddSale.GlowColor = Color.FromArgb(100, 255, 255, 255);
            siticoneBtnAddSale.GlowIntensity = 100;
            siticoneBtnAddSale.GlowRadius = 20F;
            siticoneBtnAddSale.GradientBackground = false;
            siticoneBtnAddSale.GradientColor = Color.FromArgb(0, 227, 64);
            siticoneBtnAddSale.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            siticoneBtnAddSale.HintText = null;
            siticoneBtnAddSale.HoverBackColor = Color.FromArgb(240, 240, 240);
            siticoneBtnAddSale.HoverFontStyle = FontStyle.Regular;
            siticoneBtnAddSale.HoverTextColor = Color.FromArgb(0, 0, 0);
            siticoneBtnAddSale.HoverTransitionDuration = 250;
            siticoneBtnAddSale.ImageAlign = ContentAlignment.MiddleLeft;
            siticoneBtnAddSale.ImagePadding = 5;
            siticoneBtnAddSale.ImageSize = new Size(16, 16);
            siticoneBtnAddSale.IsRadial = false;
            siticoneBtnAddSale.IsReadOnly = false;
            siticoneBtnAddSale.IsToggleButton = false;
            siticoneBtnAddSale.IsToggled = false;
            siticoneBtnAddSale.Location = new Point(523, 3);
            siticoneBtnAddSale.LongPressDurationMS = 1000;
            siticoneBtnAddSale.Name = "siticoneBtnAddSale";
            siticoneBtnAddSale.NormalFontStyle = FontStyle.Regular;
            siticoneBtnAddSale.ParticleColor = Color.FromArgb(200, 200, 200);
            siticoneBtnAddSale.ParticleCount = 15;
            siticoneBtnAddSale.PressAnimationScale = 0.97F;
            siticoneBtnAddSale.PressedBackColor = Color.FromArgb(225, 227, 230);
            siticoneBtnAddSale.PressedFontStyle = FontStyle.Regular;
            siticoneBtnAddSale.PressTransitionDuration = 150;
            siticoneBtnAddSale.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            siticoneBtnAddSale.RippleColor = Color.FromArgb(0, 0, 0);
            siticoneBtnAddSale.RippleRadiusMultiplier = 0.6F;
            siticoneBtnAddSale.ShadowBlur = 5;
            siticoneBtnAddSale.ShadowColor = Color.FromArgb(30, 0, 0, 0);
            siticoneBtnAddSale.ShadowOffset = new Point(0, 2);
            siticoneBtnAddSale.ShakeDuration = 500;
            siticoneBtnAddSale.ShakeIntensity = 5;
            siticoneBtnAddSale.Size = new Size(164, 38);
            siticoneBtnAddSale.TabIndex = 5;
            siticoneBtnAddSale.Text = "Add";
            siticoneBtnAddSale.TextAlign = ContentAlignment.MiddleCenter;
            siticoneBtnAddSale.TextColor = Color.FromArgb(0, 0, 0);
            siticoneBtnAddSale.TooltipText = null;
            siticoneBtnAddSale.UseAdvancedRendering = true;
            siticoneBtnAddSale.UseParticles = false;
            siticoneBtnAddSale.Click += siticoneBtnAddSale_Click;
            // 
            // SalesControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(siticoneBtnDeleteSale);
            Controls.Add(siticoneBtnEditSale);
            Controls.Add(siticoneBtnAddSale);
            Controls.Add(siticoneDataGridViewSaleItems);
            Controls.Add(siticoneDataGridViewSale);
            Controls.Add(siticoneButtonTextboxSearchSales);
            Name = "SalesControl";
            Size = new Size(1032, 478);
            ((System.ComponentModel.ISupportInitialize)siticoneDataGridViewSale).EndInit();
            ((System.ComponentModel.ISupportInitialize)siticoneDataGridViewSaleItems).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SiticoneNetCoreUI.SiticoneButtonTextbox siticoneButtonTextboxSearchSales;
        private SiticoneNetCoreUI.SiticoneDataGridView siticoneDataGridViewSale;
        private SiticoneNetCoreUI.SiticoneDataGridView siticoneDataGridViewSaleItems;
        private SiticoneNetCoreUI.SiticoneButton siticoneBtnDeleteSale;
        private SiticoneNetCoreUI.SiticoneButton siticoneBtnEditSale;
        private SiticoneNetCoreUI.SiticoneButton siticoneBtnAddSale;
    }
}
