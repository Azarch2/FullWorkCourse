﻿#pragma checksum "..\..\WindowAuthorization.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AFE3074B9994E56BE63291FC9C31EE14525C01D7B98BED27B4AA5E67B78B558E"
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
    /// WindowAuthorization
    /// </summary>
    public partial class WindowAuthorization : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\WindowAuthorization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock AuthAuthButton;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\WindowAuthorization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock AuthBackButton;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\WindowAuthorization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AuthTextBoxLogin;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\WindowAuthorization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox AuthTextBoxPassword;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp6;component/windowauthorization.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WindowAuthorization.xaml"
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
            
            #line 9 "..\..\WindowAuthorization.xaml"
            ((WpfApp6.WindowAuthorization)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ClickDoubleMouse);
            
            #line default
            #line hidden
            
            #line 9 "..\..\WindowAuthorization.xaml"
            ((WpfApp6.WindowAuthorization)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Close);
            
            #line default
            #line hidden
            return;
            case 2:
            this.AuthAuthButton = ((System.Windows.Controls.TextBlock)(target));
            
            #line 25 "..\..\WindowAuthorization.xaml"
            this.AuthAuthButton.MouseEnter += new System.Windows.Input.MouseEventHandler(this.AuthTextEnter);
            
            #line default
            #line hidden
            
            #line 25 "..\..\WindowAuthorization.xaml"
            this.AuthAuthButton.MouseLeave += new System.Windows.Input.MouseEventHandler(this.AuthTextLeave);
            
            #line default
            #line hidden
            return;
            case 3:
            this.AuthBackButton = ((System.Windows.Controls.TextBlock)(target));
            
            #line 26 "..\..\WindowAuthorization.xaml"
            this.AuthBackButton.MouseEnter += new System.Windows.Input.MouseEventHandler(this.AuthBackEnter);
            
            #line default
            #line hidden
            
            #line 26 "..\..\WindowAuthorization.xaml"
            this.AuthBackButton.MouseLeave += new System.Windows.Input.MouseEventHandler(this.AuthBackLeave);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AuthTextBoxLogin = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.AuthTextBoxPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
