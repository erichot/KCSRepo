﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq.Expressions;
using System.Windows.Forms;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.Skins;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using DevExpress;
using DevExpress.XtraGrid.Controls;
using DevExpress.XtraLayout;
using DevExpress.XtraCharts;
using DevExpress.DevAV;
using KCS.Common.Utils;
namespace KCS
{
    class TaskPreviewGridView : GridView
    {
        float rowFontSize = AppearanceObject.DefaultFont.Size;
        public TaskPreviewGridView()
        {
            Appearance.Row.Font = FontResources.GetSegoeUIFont(4);
            OptionsSelection.EnableAppearanceHideSelection = false;
            OptionsView.AutoCalcPreviewLineCount = true;
            OptionsView.EnableAppearanceEvenRow = true;
            OptionsView.ShowGroupPanel = false;
            OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            OptionsView.ShowIndicator = false;
            OptionsView.ShowPreview = true;
            OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            PreviewIndent = 0;
            this.RowCellStyle += (s, e) =>
            {
                e.Appearance.Font = FontResources.GetFont(e.Appearance.Font.FontFamily.Name, rowFontSize, e.Appearance.Font.Style);
                if (e.RowHandle == FocusedRowHandle && GridControl.Focused)
                    e.Appearance.BackColor = PaintAppearance.FocusedRow.BackColor;
                else SetEvenRowAppearance(e.Appearance, e.RowHandle);
            };
            this.CustomDrawRowPreview += (s, e) =>
            {
                if (e.RowHandle == FocusedRowHandle && GridControl.Focused)
                {
                    e.Appearance.BackColor = PaintAppearance.FocusedRow.BackColor;
                    e.Appearance.ForeColor = PaintAppearance.FocusedRow.ForeColor;
                }
                else SetEvenRowAppearance(e.Appearance, e.RowHandle);
            };
        }
        void SetEvenRowAppearance(AppearanceObject appearance, int rowHandle)
        {
            if (rowHandle % 2 == 0)
                appearance.BackColor = PaintAppearance.EvenRow.BackColor;
            else appearance.BackColor = PaintAppearance.Row.BackColor;
        }
        public void SetViewFontSize(float rowFontSize, float previewFontSize)
        {
            if (previewFontSize > 0)
                Appearance.Preview.Font = FontResources.GetSegoeUIFont(previewFontSize);
            if (rowFontSize > 0)
            {
                this.rowFontSize += rowFontSize;
                Appearance.Row.Font = FontResources.GetSegoeUIFont(4);
            }
        }
        protected override bool IsAllowPixelScrollingPreview
        {
            get { return true; }
        }
    }
 
    static class GalleryItemAppearances
    {
        public static void Apply(RibbonGalleryBarItem galleryItem)
        {
            galleryItem.Gallery.Appearance.ItemCaptionAppearance.Normal.Font = AppearanceObject.DefaultFont;
            galleryItem.Gallery.Appearance.ItemCaptionAppearance.Normal.Options.UseFont = true;
            galleryItem.Gallery.Appearance.ItemCaptionAppearance.Normal.TextOptions.HAlignment = HorzAlignment.Near;
            galleryItem.Gallery.Appearance.ItemCaptionAppearance.Normal.Options.UseTextOptions = true;
            galleryItem.Gallery.Appearance.ItemCaptionAppearance.Hovered.Font = AppearanceObject.DefaultFont;
            galleryItem.Gallery.Appearance.ItemCaptionAppearance.Hovered.Options.UseFont = true;
            galleryItem.Gallery.Appearance.ItemCaptionAppearance.Hovered.TextOptions.HAlignment = HorzAlignment.Near;
            galleryItem.Gallery.Appearance.ItemCaptionAppearance.Hovered.Options.UseTextOptions = true;
            galleryItem.Gallery.Appearance.ItemCaptionAppearance.Pressed.Font = AppearanceObject.DefaultFont;
            galleryItem.Gallery.Appearance.ItemCaptionAppearance.Pressed.Options.UseFont = true;
            galleryItem.Gallery.Appearance.ItemCaptionAppearance.Pressed.TextOptions.HAlignment = HorzAlignment.Near;
            galleryItem.Gallery.Appearance.ItemCaptionAppearance.Pressed.Options.UseTextOptions = true;
            galleryItem.Gallery.Appearance.ItemCaptionAppearance.Disabled.Font = AppearanceObject.DefaultFont;
            galleryItem.Gallery.Appearance.ItemCaptionAppearance.Disabled.Options.UseFont = true;
            galleryItem.Gallery.Appearance.ItemCaptionAppearance.Disabled.TextOptions.HAlignment = HorzAlignment.Near;
            galleryItem.Gallery.Appearance.ItemCaptionAppearance.Disabled.Options.UseTextOptions = true;
        }
    }
    static class FiltersTreeListAppearances
    {
        public static void Apply(DevExpress.XtraTreeList.TreeList treeList)
        {
            treeList.BackColor = System.Drawing.Color.Transparent;
            treeList.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            treeList.Appearance.Empty.Options.UseBackColor = true;
            treeList.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            treeList.Appearance.Row.Options.UseBackColor = true;
            treeList.LookAndFeel.StyleChanged += LookAndFeel_StyleChanged;
            var font = FontResources.GetSegoeUIFont(System.Drawing.FontStyle.Bold);
            treeList.Appearance.FocusedRow.Font = font;
            treeList.Appearance.FocusedRow.Options.UseFont = true;
            treeList.Appearance.HideSelectionRow.Font = font;
            treeList.Appearance.HideSelectionRow.Options.UseFont = true;
            treeList.Appearance.SelectedRow.Font = font;
            treeList.Appearance.SelectedRow.Options.UseFont = true;
        }
        static void LookAndFeel_StyleChanged(object sender, EventArgs e)
        {
            var lf = (DevExpress.LookAndFeel.UserLookAndFeel)sender;
            if (lf != null)
            {
                var treeList = lf.OwnerControl as DevExpress.XtraTreeList.TreeList;
                if (treeList != null)
                    treeList.Appearance.Row.ForeColor = GridHelper.GetTransparentRowForeColor(lf);
            }
        }
    }
    static class GroupFiltersListViewAppearances
    {
        public static void Apply(DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView winExplorerView)
        {
            winExplorerView.Appearance.ItemDescriptionNormal.ForeColor = ColorHelper.DisabledTextColor;
            winExplorerView.Appearance.ItemDescriptionNormal.Options.UseForeColor = true;
            winExplorerView.Appearance.ItemDescriptionHovered.ForeColor = ColorHelper.DisabledTextColor;
            winExplorerView.Appearance.ItemDescriptionHovered.Options.UseForeColor = true;
            winExplorerView.Appearance.ItemDescriptionPressed.ForeColor = ColorHelper.DisabledTextColor;
            winExplorerView.Appearance.ItemDescriptionPressed.Options.UseForeColor = true;
        }
    }
    static class AppHelper
    {
        public static void ProcessStart(string name)
        {
            ProcessStart(name, string.Empty);
        }
        public static void ProcessStart(string name, string arguments)
        {
            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.FileName = name;
                process.StartInfo.Arguments = arguments;
                process.StartInfo.Verb = "Open";
                process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                process.Start();
            }
            catch (System.ComponentModel.Win32Exception) { }
        }
        public static Icon AppIcon
        {
            get { return DevExpress.Utils.ResourceImageHelper.CreateIconFromResourcesEx("KCS.Resources.AppIcon.ico", typeof(MainForm).Assembly); }
        }
        static Image img;
        public static Image AppImage
        {
            get
            {
                if (img == null)
                    img = AppIcon.ToBitmap();
                return img;
            }
        }
        static WeakReference wRef;
        public static MainForm MainForm
        {
            get { return (wRef != null) ? wRef.Target as MainForm : null; }
            set { wRef = new WeakReference(value); }
        }
        public static float GetDefaultSize() { return 8.25F; } // 8.25F
        public static float GetDefaultChSize() { return 9.25F; }
    }
    static class GridHelper
    {
        public static void SetFindControlImages(GridControl grid) { SetFindControlImages(grid, true); }
        public static void SetFindControlImages(GridControl grid, bool forceAlignment)
        {

            DevExpress.XtraGrid.Controls.FindControl fControl = null;
            foreach (Control ctrl in grid.Controls)
            {
                fControl = ctrl as DevExpress.XtraGrid.Controls.FindControl;
                if (fControl != null) break;
            }
            if (fControl != null)
            {
                EditorButton btn = fControl.FindEdit.Properties.Buttons[0];
                btn.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Search;
                btn = new EditorButton(ButtonPredefines.Close);
                btn.Visible = false;
                fControl.FindEdit.Properties.Buttons.Add(btn);
                fControl.FindEdit.ButtonClick += (s, e) =>
                {
                    if (!e.Button.IsDefaultButton)
                    {
                        ButtonEdit edit = s as ButtonEdit;
                        edit.Text = string.Empty;
                    }
                };
                fControl.FindEdit.EditValueChanged += (s, e) =>
                {
                    MRUEdit edit = s as MRUEdit;
                    edit.Properties.BeginUpdate();
                    try
                    {
                        edit.Properties.Buttons[0].Visible = string.IsNullOrEmpty(edit.Text);
                        edit.Properties.Buttons[1].Visible = !string.IsNullOrEmpty(edit.Text);
                    }
                    finally
                    {
                        edit.Properties.EndUpdate();
                    }
                };
                if (forceAlignment)
                {
                    LayoutControl lc = fControl.FindEdit.Parent as LayoutControl;
                    lc.BeginUpdate();
                    try
                    {
                        for (int i = lc.Root.Items.Count - 1; i >= 0; i--)
                        {
                            LayoutControlItem item = lc.Root.Items[i] as LayoutControlItem;
                            if (item == null) continue;
                            if (item.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Never)
                                lc.Root.Remove(item);
                            else item.ControlAlignment = System.Drawing.ContentAlignment.MiddleRight;
                        }
                    }
                    finally
                    {
                        lc.EndUpdate();
                    }
                }
            }
        }
        internal static void HideCustomization(Control control)
        {
            if (control == null) return;
            foreach (Control child in control.Controls)
            {
                GridControl grid = child as GridControl;
                if (grid != null)
                {
                    GridView gridView = grid.MainView as GridView;
                    if (gridView != null)
                        gridView.HideCustomization();
                    continue;
                }
                else HideCustomization(child);
            }
        }
        internal static Color GetTransparentRowForeColor(DevExpress.LookAndFeel.UserLookAndFeel lf)
        {
            return
               (DevExpress.Utils.Frames.FrameHelper.IsDarkSkin(lf) || lf.ActiveSkinName == "VS2010") ?
               (lf.ActiveSkinName == "VS2010" ? ColorHelper.GetControlColor(lf) : ColorHelper.TextColor) : Color.Empty;
        }
    }
    static class ChartHelper
    {
        internal static Color GetBackColor(DevExpress.XtraCharts.ChartControl chartControl)
        {
            return ((DevExpress.XtraCharts.Native.IChartContainer)chartControl).Chart.ActualBackColor;
        }
    }
    class LabelTabController
    {
        LabelControl[] labels;
        public LabelTabController(object eValue, params LabelControl[] list)
        {
            this.labels = list;
            EditValue = eValue;
            foreach (LabelControl lb in list)
                lb.Click += (s, e) => EditValue = ((LabelControl)s).Tag;
        }
        object editValueCore;
        public object EditValue
        {
            get { return editValueCore; }
            set
            {
                if (object.Equals(editValueCore, value)) return;
                editValueCore = value;
                OnEditValueChanged();
            }
        }
        void OnEditValueChanged()
        {
            UpdateAppearance();
            RaiseEditValueChanged();
        }
        void UpdateAppearance()
        {
            foreach (LabelControl lc in labels)
            {
                bool isSelected = EditValue.Equals(lc.Tag);
                lc.Font = FontResources.GetFont(lc.Font.FontFamily.Name, 10.25f, isSelected ? FontStyle.Bold : FontStyle.Regular);
                lc.Appearance.ForeColor = isSelected ? ColorHelper.QuestionColor : Color.Empty;
            }
        }
        public event EventHandler EditValueChanged;
        void RaiseEditValueChanged()
        {
            EventHandler handler = EditValueChanged;
            if (handler != null) handler(EditValue, EventArgs.Empty);
        }
    }
    static class FontResources
    {
        static IDictionary<string, Font> cache;
        static FontResources()
        {
            cache = new Dictionary<string, Font>();
        }
        public static Font GetSegoeUIFont(FontStyle fontStyle)
        {
            float defaultSize = DevExpress.Utils.AppearanceObject.DefaultFont.Size;
            return GetFont("Segoe UI", defaultSize, fontStyle);
        }
        public static Font GetSegoeUIFont(float sizeGrow = 0)
        {
            float defaultSize = DevExpress.Utils.AppearanceObject.DefaultFont.Size;
            return GetFont("Segoe UI", defaultSize + sizeGrow);
        }
        public static Font GetSegoeUILightFont(float sizeGrow = 0)
        {
            float defaultSize = DevExpress.Utils.AppearanceObject.DefaultFont.Size;
            return GetFont("Segoe UI Light", defaultSize + sizeGrow);
        }
        public static Font GetFont(string familyName, float size, FontStyle style = FontStyle.Regular)
        {
            string key = familyName + "#" + size.ToString();
            if (style != FontStyle.Regular)
                key += ("#" + style.ToString());
            Font result;
            if (!cache.TryGetValue(key, out result))
            {
                try
                {
                    var family = FindFontFamily(familyName);
                    result = new Font(family ?? FontFamily.GenericSansSerif, size, style);
                }
                catch (ArgumentException) { result = DevExpress.Utils.AppearanceObject.DefaultFont; }
                cache.Add(key, result);
            }
            return result;
        }
        static FontFamily FindFontFamily(string familyName)
        {
            return Array.Find(FontFamily.Families, (f) => f.Name == familyName);
        }
    }
    static class ColorHelper
    {
        public static Color GetControlColor(DevExpress.LookAndFeel.UserLookAndFeel provider)
        {
            return DevExpress.LookAndFeel.LookAndFeelHelper.GetSystemColor(provider, SystemColors.Control);
        }
        public static Color TextColor
        {
            get { return CommonSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default).Colors.GetColor(CommonColors.ControlText); }
        }
        public static Color WindowColor
        {
            get { return CommonSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default).Colors.GetColor(CommonColors.Window); }
        }
        public static Color WindowTextColor
        {
            get { return CommonSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default).Colors.GetColor(CommonColors.WindowText); }
        }
        public static Color DisabledTextColor
        {
            get { return CommonSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default).Colors.GetColor(CommonColors.DisabledText); }
        }
        public static Color CriticalColor
        {
            get { return CommonColors.GetCriticalColor(DevExpress.LookAndFeel.UserLookAndFeel.Default); }
        }
        public static Color WarningColor
        {
            get { return CommonColors.GetWarningColor(DevExpress.LookAndFeel.UserLookAndFeel.Default); }
        }
        public static Color QuestionColor
        {
            get { return CommonColors.GetQuestionColor(DevExpress.LookAndFeel.UserLookAndFeel.Default); }
        }
        public static Color InformationColor
        {
            get { return CommonColors.GetInformationColor(DevExpress.LookAndFeel.UserLookAndFeel.Default); }
        }
    }
    static class EditorHelpers
    {
        public static RepositoryItemImageComboBox CreatePersonPrefixImageComboBox(RepositoryItemImageComboBox edit = null, RepositoryItemCollection collection = null)
        {
            RepositoryItemImageComboBox ret = CreateEnumImageComboBox<PersonPrefix>(edit, collection);
            ret.SmallImages = CreatePersonPrefixImageCollection();
            if (edit == null)
                ret.GlyphAlignment = HorzAlignment.Center;
            return ret;
        }
        public static RepositoryItemImageComboBox CreateTaskPriorityImageComboBox(RepositoryItemImageComboBox edit = null, RepositoryItemCollection collection = null)
        {
            RepositoryItemImageComboBox ret = CreateEnumImageComboBox<EmployeeTaskPriority>(edit, collection);
            ret.SmallImages = CreateTaskPriorityImageCollection();
            if (edit == null)
                ret.GlyphAlignment = HorzAlignment.Center;
            return ret;
        }
        static ImageCollection CreatePersonPrefixImageCollection()
        {
            //ImageCollection ret = new ImageCollection();
            //ret.ImageSize = new Size(16, 16);
            //ret.AddImage(Properties.Resources.Doctor);
            //ret.AddImage(Properties.Resources.Mr);
            //ret.AddImage(Properties.Resources.Ms);
            //ret.AddImage(Properties.Resources.Miss);
            //ret.AddImage(Properties.Resources.Mrs);
            //return ret;
            return null;
        }
        static ImageCollection CreateTaskPriorityImageCollection()
        {
            //ImageCollection ret = new ImageCollection();
            //ret.ImageSize = new Size(16, 16);
            //ret.AddImage(Properties.Resources.LowPriority);
            //ret.AddImage(Properties.Resources.NormalPriority);
            //ret.AddImage(Properties.Resources.MediumPriority);
            //ret.AddImage(Properties.Resources.HighPriority);
            //return ret;
            return null;
        }
        public static RepositoryItemImageComboBox CreateManeuverImageComboBox(RepositoryItemImageComboBox edit = null, RepositoryItemCollection collection = null)
        {
            //RepositoryItemImageComboBox ret = CreateEnumImageComboBox<DevExpress.XtraMap.BingManeuverType>(edit, collection);
            //foreach (ImageComboBoxItem item in ret.Items)
            //{
            //    switch ((DevExpress.XtraMap.BingManeuverType)item.Value)
            //    {
            //        case DevExpress.XtraMap.BingManeuverType.DepartStart:
            //            item.ImageIndex = 0;
            //            break;
            //        case DevExpress.XtraMap.BingManeuverType.TurnLeft:
            //            item.ImageIndex = 1;
            //            break;
            //        case DevExpress.XtraMap.BingManeuverType.TurnRight:
            //            item.ImageIndex = 2;
            //            break;
            //        case DevExpress.XtraMap.BingManeuverType.ArriveFinish:
            //            item.ImageIndex = 3;
            //            break;
            //        case DevExpress.XtraMap.BingManeuverType.UTurn:
            //            item.ImageIndex = 4;
            //            break;
            //        case DevExpress.XtraMap.BingManeuverType.BearLeft:
            //            item.ImageIndex = 5;
            //            break;
            //        case DevExpress.XtraMap.BingManeuverType.BearRight:
            //            item.ImageIndex = 6;
            //            break;
            //    }
            //    item.Description = string.Empty;
            //}
            //ret.SmallImages = CreateBingManeuverTypeImageCollection();
            //ret.GlyphAlignment = HorzAlignment.Center;
            //return ret;
            return null;
        }
        static ImageCollection CreateBingManeuverTypeImageCollection()
        {
            //ImageCollection ret = new ImageCollection();
            //ret.ImageSize = new Size(32, 32);
            //ret.AddImage(Properties.Resources.icon_A_32);
            //ret.AddImage(Properties.Resources.icon_arrow_left_32);
            //ret.AddImage(Properties.Resources.icon_arrow_right_32);
            //ret.AddImage(Properties.Resources.icon_B_32);
            //ret.AddImage(Properties.Resources.icon_arrow_uturn_32);
            //ret.AddImage(Properties.Resources.icon_arrow_bear_left_32);
            //ret.AddImage(Properties.Resources.icon_arrow_bear_right_32);
            //ret.AddImage(Properties.Resources.icon_arrow_forward_32);
            //return ret;
            return null;
        }
        public static RepositoryItemImageComboBox CreateEnumImageComboBox<TEnum>(DevExpress.XtraEditors.Container.EditorContainer container,
            Converter<TEnum, string> displayTextConverter = null)
        {
            return CreatEdit<RepositoryItemImageComboBox>(null, (container != null) ? container.RepositoryItems : null, (e) => e.Items.AddEnum<TEnum>(displayTextConverter));
        }
        public static RepositoryItemImageComboBox CreateEnumImageComboBox<TEnum>(RepositoryItemImageComboBox edit = null, RepositoryItemCollection collection = null,
            Converter<TEnum, string> displayTextConverter = null)
        {
            return CreatEdit<RepositoryItemImageComboBox>(edit, collection, (e) => e.Items.AddEnum<TEnum>(displayTextConverter));
        }
        public static RepositoryItemDateEdit CreatDateEdit(RepositoryItemDateEdit edit = null, RepositoryItemCollection collection = null)
        {
            return CreatEdit<RepositoryItemDateEdit>(edit, collection);
        }
        public static TEdit CreatEdit<TEdit>(TEdit edit = null, RepositoryItemCollection collection = null, Action<TEdit> initialize = null)
            where TEdit : RepositoryItem, new()
        {
            edit = edit ?? new TEdit();
            if (collection != null) collection.Add(edit);
            if (initialize != null)
                initialize(edit);
            return edit;
        }
        public static void ApplyBindingSettings<TEntity>(BaseEdit edit, LayoutControl layoutControl)
        {
            var memberInfo = edit.DataBindings["EditValue"].BindingMemberInfo;
            if (DataAnnotationHelper.IsRequired<TEntity>(memberInfo.BindingMember))
            {
                if (layoutControl != null)
                {
                    var itemForEdit = layoutControl.GetItemByControl(edit);
                    itemForEdit.AllowHtmlStringInCaption = true;
                    itemForEdit.Text = itemForEdit.Text + " <color=red>*</color>";
                }
            }
            //if (edit is TextEdit)
            //{
            //    if (DataAnnotationHelper.IsPhone<TEntity>(memberInfo.BindingMember))
            //    {
            //        ((TextEdit)edit).Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            //        ((TextEdit)edit).Properties.Mask.EditMask = "(999) 000-0000";
            //        ((TextEdit)edit).Properties.Mask.UseMaskAsDisplayFormat = true;
            //    }
            //    if (DataAnnotationHelper.IsZipcode<TEntity>(memberInfo.BindingMember))
            //    {
            //        ((TextEdit)edit).Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            //        ((TextEdit)edit).Properties.Mask.EditMask = "00000";
            //        ((TextEdit)edit).Properties.Mask.UseMaskAsDisplayFormat = true;
            //    }
            //}
        }
    }
    class FilterColumnCollectionBuilder<TEntity>
    {
        FilterColumnCollection filterColumns;
        public FilterColumnCollectionBuilder()
        {
            this.filterColumns = new FilterColumnCollection();
        }
        public FilterColumnCollectionBuilder(FilterColumnCollection filterColumns)
        {
            this.filterColumns = filterColumns;
        }
        public FilterColumnCollection Build()
        {
            return filterColumns;
        }
        public FilterColumnCollectionBuilder<TEntity> AddColumn<T>(Expression<Func<TEntity, T>> expression,
            DevExpress.XtraEditors.Repository.RepositoryItem repositoryItem = null,
            FilterColumnClauseClass clauseClass = FilterColumnClauseClass.String, string caption = null)
        {
            if (repositoryItem == null)
            {
                if (typeof(T) == typeof(bool) || (typeof(T) == typeof(bool?)))
                {
                    repositoryItem = EditorHelpers.CreatEdit<RepositoryItemCheckEdit>();
                    clauseClass = FilterColumnClauseClass.Generic;
                }
                if ((typeof(T) == typeof(double)) || (typeof(T) == typeof(double?)) || (typeof(T) == typeof(decimal)) || (typeof(T) == typeof(decimal?)))
                {
                    repositoryItem = EditorHelpers.CreatEdit<RepositoryItemSpinEdit>();
                    clauseClass = FilterColumnClauseClass.Generic;
                }
                if (typeof(T) == typeof(int) || (typeof(T) == typeof(int?)))
                {
                    var spinEdit = EditorHelpers.CreatEdit<RepositoryItemSpinEdit>();
                    spinEdit.IsFloatValue = false;
                    repositoryItem = spinEdit;
                    clauseClass = FilterColumnClauseClass.Generic;
                }
            }
            filterColumns.Add(CreateColumn(expression, caption, null, repositoryItem, clauseClass));
            return this;
        }
        public FilterColumnCollectionBuilder<TEntity> AddLookupColumn<T>(Expression<Func<TEntity, T>> expression)
        {
            return AddColumn(expression, EditorHelpers.CreateEnumImageComboBox<T>(), FilterColumnClauseClass.Lookup);
        }
        public FilterColumnCollectionBuilder<TEntity> AddDateTimeColumn<T>(Expression<Func<TEntity, T>> expression)
        {
            return AddColumn(expression, EditorHelpers.CreatDateEdit(), FilterColumnClauseClass.DateTime);
        }
        UnboundFilterColumn CreateColumn<T>(Expression<Func<TEntity, T>> expression, string caption, string fieldName,
            DevExpress.XtraEditors.Repository.RepositoryItem repositoryItem, FilterColumnClauseClass clauseClass)
        {
            var member = (expression.Body as MemberExpression).Member;
            if (string.IsNullOrEmpty(fieldName))
                fieldName = GetFieldName<T>(expression);
            if (string.IsNullOrEmpty(caption))
                caption = GetDisplayName(member);
            return CreateColumn<T>(caption, fieldName, repositoryItem, clauseClass);
        }
        UnboundFilterColumn CreateColumn<T>(string caption, string fieldName,
            DevExpress.XtraEditors.Repository.RepositoryItem repositoryItem, FilterColumnClauseClass clauseClass)
        {
            return new UnboundFilterColumn(caption, fieldName, typeof(T), repositoryItem, clauseClass);
        }
        string GetFieldName<T>(Expression<Func<TEntity, T>> expression)
        {
            var sb = new System.Text.StringBuilder();
            MemberExpression me = expression.Body as MemberExpression;
            while (me != null)
            {
                if (sb.Length > 0)
                    sb.Insert(0, ".");
                sb.Insert(0, me.Member.Name);
                me = me.Expression as MemberExpression;
            }
            return sb.ToString();
        }
        string GetDisplayName(System.Reflection.MemberInfo member)
        {
            string displayName = member.Name;
            if (CheckDisplayNameAttribute<System.ComponentModel.DataAnnotations.DisplayAttribute>(member, a => a.GetName(), ref displayName))
                return displayName;
            if (CheckDisplayNameAttribute<System.ComponentModel.DisplayNameAttribute>(member, a => a.DisplayName, ref displayName))
                return displayName;
            return displayName;
        }
        bool CheckDisplayNameAttribute<TAttribute>(System.Reflection.MemberInfo member, Func<TAttribute, string> accessor, ref string displayName)
            where TAttribute : Attribute
        {
            var displayAttributes = member.GetCustomAttributes(typeof(TAttribute), true);
            if (displayAttributes.Length > 0)
            {
                displayName = accessor((TAttribute)displayAttributes[0]);
                return true;
            }
            return false;
        }
    }
    static class FilterControlWithoutLike
    {
        public static void Apply(FilterControl filterControl)
        {
            filterControl.PopupMenuShowing += filterControl_PopupMenuShowing;
        }
        static void filterControl_PopupMenuShowing(object sender, DevExpress.XtraEditors.Filtering.PopupMenuShowingEventArgs e)
        {
            for (int i = e.Menu.Items.Count - 1; i >= 0; i--)
            {
                if (e.Menu.Items[i].Caption == Localizer.Active.GetLocalizedString(StringId.FilterClauseLike) ||
                    e.Menu.Items[i].Caption == Localizer.Active.GetLocalizedString(StringId.FilterClauseNotLike))
                {
                    e.Menu.Items.RemoveAt(i);
                }
            }
        }
    }
    class DemoStartUp : IObserver<string>
    {
        void IObserver<string>.OnCompleted()
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();
        }
        void IObserver<string>.OnNext(string status)
        {
            
            if (DevExpress.XtraSplashScreen.SplashScreenManager.Default == null)
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(AppHelper.MainForm, typeof(SplashScreenKCS),true, true);
               // DevExpress.XtraSplashScreen.SplashScreenManager.ShowDefaultSplashScreen(AppHelper.MainForm, true, true, "DevExpress WinForms Controls", status);
            }
            else
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.SetDefaultSplashScreenStatus(false, status);
            }
        }
        void IObserver<string>.OnError(Exception error) { throw error; }
    }
    class DataGenerationProgress : IObserver<string>
    {
        void IObserver<string>.OnNext(string status)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.SetDefaultSplashScreenStatus(false, status);
        }
        void IObserver<string>.OnCompleted() { }
        void IObserver<string>.OnError(Exception error) { throw error; }
    }
    public class EntityEventArgs<TID> : EventArgs
    {
        TID entityKeyCore;
        public EntityEventArgs(TID entityKey)
        {
            this.entityKeyCore = entityKey;
        }
        public TID Key
        {
            get { return entityKeyCore; }
        }
    }
    public class EntitiesCountEventArgs : EventArgs
    {
        public EntitiesCountEventArgs(int count)
        {
            Count = count;
        }
        public int Count { get; private set; }
    }
    public class GroupEventArgs<TKey> : EventArgs
    {
        IEnumerable<TKey> keysCore;
        public GroupEventArgs(IEnumerable<TKey> keys)
        {
            this.keysCore = keys;
        }
        public IEnumerable<TKey> Entities
        {
            get { return keysCore; }
        }
    }
}
