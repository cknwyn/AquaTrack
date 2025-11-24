namespace AquaTrack.Pages.Input_Forms
{
    partial class SaleItemsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaleItemsForm));
            siticoneDropdownSaleItemProduct = new SiticoneNetCoreUI.SiticoneDropdown();
            siticoneUpDown1 = new SiticoneNetCoreUI.SiticoneUpDown();
            siticoneLabelSaleItemProduct = new SiticoneNetCoreUI.SiticoneLabel();
            siticoneLabelSaleItemQuantity = new SiticoneNetCoreUI.SiticoneLabel();
            siticoneButtonSaleItemConfirm = new SiticoneNetCoreUI.SiticoneButton();
            siticoneButtonSaleItemCancel = new SiticoneNetCoreUI.SiticoneButton();
            SuspendLayout();
            // 
            // siticoneDropdownSaleItemProduct
            // 
            siticoneDropdownSaleItemProduct.AllowMultipleSelection = false;
            siticoneDropdownSaleItemProduct.BackColor = Color.FromArgb(240, 245, 255);
            siticoneDropdownSaleItemProduct.BorderColor = Color.FromArgb(100, 150, 220);
            siticoneDropdownSaleItemProduct.CanBeep = false;
            siticoneDropdownSaleItemProduct.CanShake = true;
            siticoneDropdownSaleItemProduct.DataSource = null;
            siticoneDropdownSaleItemProduct.DisplayMember = null;
            siticoneDropdownSaleItemProduct.DropdownBackColor = Color.FromArgb(245, 250, 255);
            siticoneDropdownSaleItemProduct.DropdownWidth = 0;
            siticoneDropdownSaleItemProduct.DropShadowEnabled = false;
            siticoneDropdownSaleItemProduct.Font = new Font("Segoe UI", 10F);
            siticoneDropdownSaleItemProduct.ForeColor = Color.FromArgb(40, 40, 100);
            siticoneDropdownSaleItemProduct.HoveredItemBackColor = Color.FromArgb(220, 235, 255);
            siticoneDropdownSaleItemProduct.HoveredItemTextColor = Color.FromArgb(40, 40, 100);
            siticoneDropdownSaleItemProduct.IsReadonly = false;
            siticoneDropdownSaleItemProduct.ItemHeight = 30;
            siticoneDropdownSaleItemProduct.Location = new Point(38, 41);
            siticoneDropdownSaleItemProduct.MaxDropDownItems = 8;
            siticoneDropdownSaleItemProduct.Name = "siticoneDropdownSaleItemProduct";
            siticoneDropdownSaleItemProduct.PlaceholderColor = Color.FromArgb(150, 170, 200);
            siticoneDropdownSaleItemProduct.PlaceholderDisappearsOnFocus = false;
            siticoneDropdownSaleItemProduct.PlaceholderText = "Select an option";
            siticoneDropdownSaleItemProduct.SelectedIndex = -1;
            siticoneDropdownSaleItemProduct.SelectedItem = null;
            siticoneDropdownSaleItemProduct.SelectedItemBackColor = Color.FromArgb(70, 130, 220);
            siticoneDropdownSaleItemProduct.SelectedItemTextColor = Color.White;
            siticoneDropdownSaleItemProduct.SelectedValue = null;
            siticoneDropdownSaleItemProduct.Size = new Size(345, 40);
            siticoneDropdownSaleItemProduct.TabIndex = 0;
            siticoneDropdownSaleItemProduct.Text = "siticoneDropdown1";
            siticoneDropdownSaleItemProduct.UnselectedItemTextColor = Color.FromArgb(40, 40, 100);
            siticoneDropdownSaleItemProduct.ValueMember = null;
            siticoneDropdownSaleItemProduct.Click += siticoneDropdownSaleItemProduct_Click;
            // 
            // siticoneUpDown1
            // 
            siticoneUpDown1.AccessibleDescription = "An advanced numeric up/down control.";
            siticoneUpDown1.AccessibleName = "SiticoneUpDown";
            siticoneUpDown1.AccessibleRole = AccessibleRole.SpinButton;
            siticoneUpDown1.ActiveBorderColor = Color.DodgerBlue;
            siticoneUpDown1.AllowMouseWheel = true;
            siticoneUpDown1.AnimateValueChanges = true;
            siticoneUpDown1.BackColor = Color.Transparent;
            siticoneUpDown1.BorderColor = Color.Gray;
            siticoneUpDown1.CanBeep = true;
            siticoneUpDown1.CanShake = true;
            siticoneUpDown1.CornerRadiusBottomLeft = 4;
            siticoneUpDown1.CornerRadiusBottomRight = 4;
            siticoneUpDown1.CornerRadiusTopLeft = 4;
            siticoneUpDown1.CornerRadiusTopRight = 4;
            siticoneUpDown1.DecimalPlaces = 0;
            siticoneUpDown1.EnableDirectInput = false;
            siticoneUpDown1.FillColor = Color.White;
            siticoneUpDown1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            siticoneUpDown1.ForeColor = Color.Black;
            siticoneUpDown1.GradientColorEnd = Color.LightGray;
            siticoneUpDown1.GradientColorStart = Color.White;
            siticoneUpDown1.GradientMode = SiticoneNetCoreUI.Helpers.Enum.GradientModes.None;
            siticoneUpDown1.HoverBorderColor = Color.Blue;
            siticoneUpDown1.Increment = new decimal(new int[] { 1, 0, 0, 0 });
            siticoneUpDown1.InitialRepeatDelay = 500;
            siticoneUpDown1.InputType = SiticoneNetCoreUI.Helpers.Enum.InputType.Decimals;
            siticoneUpDown1.IsReadOnly = false;
            siticoneUpDown1.Location = new Point(38, 117);
            siticoneUpDown1.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            siticoneUpDown1.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            siticoneUpDown1.Name = "siticoneUpDown1";
            siticoneUpDown1.RepeatSpeed = 50;
            siticoneUpDown1.ShowBorder = true;
            siticoneUpDown1.Size = new Size(345, 40);
            siticoneUpDown1.StepPoints = (List<decimal>)resources.GetObject("siticoneUpDown1.StepPoints");
            siticoneUpDown1.TabIndex = 1;
            siticoneUpDown1.Text = "0";
            siticoneUpDown1.TextAlignment = SiticoneNetCoreUI.Helpers.Text.TextAlignment.Right;
            siticoneUpDown1.UseGradient = false;
            siticoneUpDown1.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // siticoneLabelSaleItemProduct
            // 
            siticoneLabelSaleItemProduct.BackColor = Color.Transparent;
            siticoneLabelSaleItemProduct.Font = new Font("Segoe UI", 10F);
            siticoneLabelSaleItemProduct.Location = new Point(38, 15);
            siticoneLabelSaleItemProduct.Name = "siticoneLabelSaleItemProduct";
            siticoneLabelSaleItemProduct.Size = new Size(100, 23);
            siticoneLabelSaleItemProduct.TabIndex = 2;
            siticoneLabelSaleItemProduct.Text = "Product";
            // 
            // siticoneLabelSaleItemQuantity
            // 
            siticoneLabelSaleItemQuantity.BackColor = Color.Transparent;
            siticoneLabelSaleItemQuantity.Font = new Font("Segoe UI", 10F);
            siticoneLabelSaleItemQuantity.Location = new Point(38, 91);
            siticoneLabelSaleItemQuantity.Name = "siticoneLabelSaleItemQuantity";
            siticoneLabelSaleItemQuantity.Size = new Size(100, 23);
            siticoneLabelSaleItemQuantity.TabIndex = 3;
            siticoneLabelSaleItemQuantity.Text = "Quantity";
            // 
            // siticoneButtonSaleItemConfirm
            // 
            siticoneButtonSaleItemConfirm.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            siticoneButtonSaleItemConfirm.AccessibleName = "Confirm";
            siticoneButtonSaleItemConfirm.AutoSizeBasedOnText = false;
            siticoneButtonSaleItemConfirm.BackColor = Color.Transparent;
            siticoneButtonSaleItemConfirm.BadgeBackColor = Color.Black;
            siticoneButtonSaleItemConfirm.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            siticoneButtonSaleItemConfirm.BadgeValue = 0;
            siticoneButtonSaleItemConfirm.BadgeValueForeColor = Color.White;
            siticoneButtonSaleItemConfirm.BorderColor = Color.FromArgb(213, 216, 220);
            siticoneButtonSaleItemConfirm.BorderWidth = 1;
            siticoneButtonSaleItemConfirm.ButtonBackColor = Color.FromArgb(245, 247, 250);
            siticoneButtonSaleItemConfirm.ButtonImage = null;
            siticoneButtonSaleItemConfirm.ButtonTextLeftPadding = 0;
            siticoneButtonSaleItemConfirm.CanBeep = true;
            siticoneButtonSaleItemConfirm.CanGlow = false;
            siticoneButtonSaleItemConfirm.CanShake = true;
            siticoneButtonSaleItemConfirm.ContextMenuStripEx = null;
            siticoneButtonSaleItemConfirm.CornerRadiusBottomLeft = 6;
            siticoneButtonSaleItemConfirm.CornerRadiusBottomRight = 6;
            siticoneButtonSaleItemConfirm.CornerRadiusTopLeft = 6;
            siticoneButtonSaleItemConfirm.CornerRadiusTopRight = 6;
            siticoneButtonSaleItemConfirm.CustomCursor = Cursors.Default;
            siticoneButtonSaleItemConfirm.DisabledTextColor = Color.FromArgb(150, 150, 150);
            siticoneButtonSaleItemConfirm.EnableLongPress = false;
            siticoneButtonSaleItemConfirm.EnableRippleEffect = true;
            siticoneButtonSaleItemConfirm.EnableShadow = false;
            siticoneButtonSaleItemConfirm.EnableTextWrapping = false;
            siticoneButtonSaleItemConfirm.Font = new Font("Segoe UI Semibold", 10.2F);
            siticoneButtonSaleItemConfirm.GlowColor = Color.FromArgb(100, 255, 255, 255);
            siticoneButtonSaleItemConfirm.GlowIntensity = 100;
            siticoneButtonSaleItemConfirm.GlowRadius = 20F;
            siticoneButtonSaleItemConfirm.GradientBackground = false;
            siticoneButtonSaleItemConfirm.GradientColor = Color.FromArgb(0, 227, 64);
            siticoneButtonSaleItemConfirm.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            siticoneButtonSaleItemConfirm.HintText = null;
            siticoneButtonSaleItemConfirm.HoverBackColor = Color.FromArgb(240, 240, 240);
            siticoneButtonSaleItemConfirm.HoverFontStyle = FontStyle.Regular;
            siticoneButtonSaleItemConfirm.HoverTextColor = Color.FromArgb(0, 0, 0);
            siticoneButtonSaleItemConfirm.HoverTransitionDuration = 250;
            siticoneButtonSaleItemConfirm.ImageAlign = ContentAlignment.MiddleLeft;
            siticoneButtonSaleItemConfirm.ImagePadding = 5;
            siticoneButtonSaleItemConfirm.ImageSize = new Size(16, 16);
            siticoneButtonSaleItemConfirm.IsRadial = false;
            siticoneButtonSaleItemConfirm.IsReadOnly = false;
            siticoneButtonSaleItemConfirm.IsToggleButton = false;
            siticoneButtonSaleItemConfirm.IsToggled = false;
            siticoneButtonSaleItemConfirm.Location = new Point(38, 180);
            siticoneButtonSaleItemConfirm.LongPressDurationMS = 1000;
            siticoneButtonSaleItemConfirm.Name = "siticoneButtonSaleItemConfirm";
            siticoneButtonSaleItemConfirm.NormalFontStyle = FontStyle.Regular;
            siticoneButtonSaleItemConfirm.ParticleColor = Color.FromArgb(200, 200, 200);
            siticoneButtonSaleItemConfirm.ParticleCount = 15;
            siticoneButtonSaleItemConfirm.PressAnimationScale = 0.97F;
            siticoneButtonSaleItemConfirm.PressedBackColor = Color.FromArgb(225, 227, 230);
            siticoneButtonSaleItemConfirm.PressedFontStyle = FontStyle.Regular;
            siticoneButtonSaleItemConfirm.PressTransitionDuration = 150;
            siticoneButtonSaleItemConfirm.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            siticoneButtonSaleItemConfirm.RippleColor = Color.FromArgb(0, 0, 0);
            siticoneButtonSaleItemConfirm.RippleRadiusMultiplier = 0.6F;
            siticoneButtonSaleItemConfirm.ShadowBlur = 5;
            siticoneButtonSaleItemConfirm.ShadowColor = Color.FromArgb(30, 0, 0, 0);
            siticoneButtonSaleItemConfirm.ShadowOffset = new Point(0, 2);
            siticoneButtonSaleItemConfirm.ShakeDuration = 500;
            siticoneButtonSaleItemConfirm.ShakeIntensity = 5;
            siticoneButtonSaleItemConfirm.Size = new Size(164, 38);
            siticoneButtonSaleItemConfirm.TabIndex = 4;
            siticoneButtonSaleItemConfirm.Text = "Confirm";
            siticoneButtonSaleItemConfirm.TextAlign = ContentAlignment.MiddleCenter;
            siticoneButtonSaleItemConfirm.TextColor = Color.FromArgb(0, 0, 0);
            siticoneButtonSaleItemConfirm.TooltipText = null;
            siticoneButtonSaleItemConfirm.UseAdvancedRendering = true;
            siticoneButtonSaleItemConfirm.UseParticles = false;
            siticoneButtonSaleItemConfirm.Click += siticoneButtonSaleItemConfirm_Click;
            // 
            // siticoneButtonSaleItemCancel
            // 
            siticoneButtonSaleItemCancel.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            siticoneButtonSaleItemCancel.AccessibleName = "Cancel";
            siticoneButtonSaleItemCancel.AutoSizeBasedOnText = false;
            siticoneButtonSaleItemCancel.BackColor = Color.Transparent;
            siticoneButtonSaleItemCancel.BadgeBackColor = Color.Black;
            siticoneButtonSaleItemCancel.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            siticoneButtonSaleItemCancel.BadgeValue = 0;
            siticoneButtonSaleItemCancel.BadgeValueForeColor = Color.White;
            siticoneButtonSaleItemCancel.BorderColor = Color.FromArgb(213, 216, 220);
            siticoneButtonSaleItemCancel.BorderWidth = 1;
            siticoneButtonSaleItemCancel.ButtonBackColor = Color.FromArgb(245, 247, 250);
            siticoneButtonSaleItemCancel.ButtonImage = null;
            siticoneButtonSaleItemCancel.ButtonTextLeftPadding = 0;
            siticoneButtonSaleItemCancel.CanBeep = true;
            siticoneButtonSaleItemCancel.CanGlow = false;
            siticoneButtonSaleItemCancel.CanShake = true;
            siticoneButtonSaleItemCancel.ContextMenuStripEx = null;
            siticoneButtonSaleItemCancel.CornerRadiusBottomLeft = 6;
            siticoneButtonSaleItemCancel.CornerRadiusBottomRight = 6;
            siticoneButtonSaleItemCancel.CornerRadiusTopLeft = 6;
            siticoneButtonSaleItemCancel.CornerRadiusTopRight = 6;
            siticoneButtonSaleItemCancel.CustomCursor = Cursors.Default;
            siticoneButtonSaleItemCancel.DisabledTextColor = Color.FromArgb(150, 150, 150);
            siticoneButtonSaleItemCancel.EnableLongPress = false;
            siticoneButtonSaleItemCancel.EnableRippleEffect = true;
            siticoneButtonSaleItemCancel.EnableShadow = false;
            siticoneButtonSaleItemCancel.EnableTextWrapping = false;
            siticoneButtonSaleItemCancel.Font = new Font("Segoe UI Semibold", 10.2F);
            siticoneButtonSaleItemCancel.GlowColor = Color.FromArgb(100, 255, 255, 255);
            siticoneButtonSaleItemCancel.GlowIntensity = 100;
            siticoneButtonSaleItemCancel.GlowRadius = 20F;
            siticoneButtonSaleItemCancel.GradientBackground = false;
            siticoneButtonSaleItemCancel.GradientColor = Color.FromArgb(0, 227, 64);
            siticoneButtonSaleItemCancel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            siticoneButtonSaleItemCancel.HintText = null;
            siticoneButtonSaleItemCancel.HoverBackColor = Color.FromArgb(240, 240, 240);
            siticoneButtonSaleItemCancel.HoverFontStyle = FontStyle.Regular;
            siticoneButtonSaleItemCancel.HoverTextColor = Color.FromArgb(0, 0, 0);
            siticoneButtonSaleItemCancel.HoverTransitionDuration = 250;
            siticoneButtonSaleItemCancel.ImageAlign = ContentAlignment.MiddleLeft;
            siticoneButtonSaleItemCancel.ImagePadding = 5;
            siticoneButtonSaleItemCancel.ImageSize = new Size(16, 16);
            siticoneButtonSaleItemCancel.IsRadial = false;
            siticoneButtonSaleItemCancel.IsReadOnly = false;
            siticoneButtonSaleItemCancel.IsToggleButton = false;
            siticoneButtonSaleItemCancel.IsToggled = false;
            siticoneButtonSaleItemCancel.Location = new Point(219, 180);
            siticoneButtonSaleItemCancel.LongPressDurationMS = 1000;
            siticoneButtonSaleItemCancel.Name = "siticoneButtonSaleItemCancel";
            siticoneButtonSaleItemCancel.NormalFontStyle = FontStyle.Regular;
            siticoneButtonSaleItemCancel.ParticleColor = Color.FromArgb(200, 200, 200);
            siticoneButtonSaleItemCancel.ParticleCount = 15;
            siticoneButtonSaleItemCancel.PressAnimationScale = 0.97F;
            siticoneButtonSaleItemCancel.PressedBackColor = Color.FromArgb(225, 227, 230);
            siticoneButtonSaleItemCancel.PressedFontStyle = FontStyle.Regular;
            siticoneButtonSaleItemCancel.PressTransitionDuration = 150;
            siticoneButtonSaleItemCancel.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            siticoneButtonSaleItemCancel.RippleColor = Color.FromArgb(0, 0, 0);
            siticoneButtonSaleItemCancel.RippleRadiusMultiplier = 0.6F;
            siticoneButtonSaleItemCancel.ShadowBlur = 5;
            siticoneButtonSaleItemCancel.ShadowColor = Color.FromArgb(30, 0, 0, 0);
            siticoneButtonSaleItemCancel.ShadowOffset = new Point(0, 2);
            siticoneButtonSaleItemCancel.ShakeDuration = 500;
            siticoneButtonSaleItemCancel.ShakeIntensity = 5;
            siticoneButtonSaleItemCancel.Size = new Size(164, 38);
            siticoneButtonSaleItemCancel.TabIndex = 5;
            siticoneButtonSaleItemCancel.Text = "Cancel";
            siticoneButtonSaleItemCancel.TextAlign = ContentAlignment.MiddleCenter;
            siticoneButtonSaleItemCancel.TextColor = Color.FromArgb(0, 0, 0);
            siticoneButtonSaleItemCancel.TooltipText = null;
            siticoneButtonSaleItemCancel.UseAdvancedRendering = true;
            siticoneButtonSaleItemCancel.UseParticles = false;
            siticoneButtonSaleItemCancel.Click += siticoneButtonSaleItemCancel_Click;
            // 
            // SaleItemsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(418, 230);
            Controls.Add(siticoneButtonSaleItemCancel);
            Controls.Add(siticoneButtonSaleItemConfirm);
            Controls.Add(siticoneLabelSaleItemQuantity);
            Controls.Add(siticoneLabelSaleItemProduct);
            Controls.Add(siticoneUpDown1);
            Controls.Add(siticoneDropdownSaleItemProduct);
            Name = "SaleItemsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SaleItemsForm";
            ResumeLayout(false);
        }

        #endregion

        private SiticoneNetCoreUI.SiticoneDropdown siticoneDropdownSaleItemProduct;
        private SiticoneNetCoreUI.SiticoneUpDown siticoneUpDown1;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabelSaleItemProduct;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabelSaleItemQuantity;
        private SiticoneNetCoreUI.SiticoneButton siticoneButtonSaleItemConfirm;
        private SiticoneNetCoreUI.SiticoneButton siticoneButtonSaleItemCancel;
    }
}