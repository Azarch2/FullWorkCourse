﻿#pragma checksum "..\..\WindowAddPlaceOfPhoto.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DBB70BD1314062BBB3F998AA2ACE1800EA8BEE38DBB61134BEC7FC9E93DDF300"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WpfApp6;


namespace WpfApp6 {
    
    
    /// <summary>
    /// WindowAddPlaceOfPhoto
    /// </summary>
    public partial class WindowAddPlaceOfPhoto : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\WindowAddPlaceOfPhoto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfApp6.WindowAddPlaceOfPhoto AddPlaceOfPhoto;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\WindowAddPlaceOfPhoto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border PlacePhotoAdd;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\WindowAddPlaceOfPhoto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AddPlaceTextBoxLandscape;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\WindowAddPlaceOfPhoto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AddPlaceTextBoxCountry;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\WindowAddPlaceOfPhoto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AddPlaceTextBoxCity;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\WindowAddPlaceOfPhoto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock AddPlaceAddButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfApp6;component/windowaddplaceofphoto.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WindowAddPlaceOfPhoto.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.AddPlaceOfPhoto = ((WpfApp6.WindowAddPlaceOfPhoto)(target));
            
            #line 9 "..\..\WindowAddPlaceOfPhoto.xaml"
            this.AddPlaceOfPhoto.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ClickDoubleMouse);
            
            #line default
            #line hidden
            
            #line 9 "..\..\WindowAddPlaceOfPhoto.xaml"
            this.AddPlaceOfPhoto.Closing += new System.ComponentModel.CancelEventHandler(this.AddPlaceOfPhoto_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.PlacePhotoAdd = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.AddPlaceTextBoxLandscape = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.AddPlaceTextBoxCountry = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.AddPlaceTextBoxCity = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.AddPlaceAddButton = ((System.Windows.Controls.TextBlock)(target));
            
            #line 27 "..\..\WindowAddPlaceOfPhoto.xaml"
            this.AddPlaceAddButton.MouseEnter += new System.Windows.Input.MouseEventHandler(this.AddPlaceAddEnter);
            
            #line default
            #line hidden
            
            #line 27 "..\..\WindowAddPlaceOfPhoto.xaml"
            this.AddPlaceAddButton.MouseLeave += new System.Windows.Input.MouseEventHandler(this.AddPlaceAddLeave);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
