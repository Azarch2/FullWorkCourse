﻿#pragma checksum "..\..\WindowGetAdmin.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3C9BADB7B05520D55961EFA3F5E7AE524697A43B857403578465C6CCE276034F"
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
    /// WindowGetAdmin
    /// </summary>
    public partial class WindowGetAdmin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\WindowGetAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock GetAdminBackButton;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\WindowGetAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox GetAdminTextBoxKey;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\WindowGetAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock GetAdminCheckPassword;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp6;component/windowgetadmin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WindowGetAdmin.xaml"
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
            
            #line 9 "..\..\WindowGetAdmin.xaml"
            ((WpfApp6.WindowGetAdmin)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ClickDoubleMouse);
            
            #line default
            #line hidden
            
            #line 9 "..\..\WindowGetAdmin.xaml"
            ((WpfApp6.WindowGetAdmin)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Close);
            
            #line default
            #line hidden
            return;
            case 2:
            this.GetAdminBackButton = ((System.Windows.Controls.TextBlock)(target));
            
            #line 14 "..\..\WindowGetAdmin.xaml"
            this.GetAdminBackButton.MouseEnter += new System.Windows.Input.MouseEventHandler(this.GetAdminBackEnter);
            
            #line default
            #line hidden
            
            #line 14 "..\..\WindowGetAdmin.xaml"
            this.GetAdminBackButton.MouseLeave += new System.Windows.Input.MouseEventHandler(this.GetAdminBackLeave);
            
            #line default
            #line hidden
            return;
            case 3:
            this.GetAdminTextBoxKey = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.GetAdminCheckPassword = ((System.Windows.Controls.TextBlock)(target));
            
            #line 16 "..\..\WindowGetAdmin.xaml"
            this.GetAdminCheckPassword.MouseEnter += new System.Windows.Input.MouseEventHandler(this.GetAdminCheckPasswordEnter);
            
            #line default
            #line hidden
            
            #line 16 "..\..\WindowGetAdmin.xaml"
            this.GetAdminCheckPassword.MouseLeave += new System.Windows.Input.MouseEventHandler(this.GetAdminCheckPasswordLeave);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

