﻿#pragma checksum "..\..\WindowVideoPlayer.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2CA7E95A3E7FADEA2A600654F4CDAB90C84F3AC51F038AA259AD836195E8B41F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
    /// WindowVideoPlayer
    /// </summary>
    public partial class WindowVideoPlayer : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\WindowVideoPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MediaElement PleerMedia;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\WindowVideoPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel StackPanelWithElements;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\WindowVideoPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider VideoSlider;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp6;component/windowvideoplayer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WindowVideoPlayer.xaml"
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
            
            #line 8 "..\..\WindowVideoPlayer.xaml"
            ((WpfApp6.WindowVideoPlayer)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.MouseEnter);
            
            #line default
            #line hidden
            
            #line 8 "..\..\WindowVideoPlayer.xaml"
            ((WpfApp6.WindowVideoPlayer)(target)).KeyUp += new System.Windows.Input.KeyEventHandler(this.backToPreviousIcon);
            
            #line default
            #line hidden
            
            #line 8 "..\..\WindowVideoPlayer.xaml"
            ((WpfApp6.WindowVideoPlayer)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Close);
            
            #line default
            #line hidden
            return;
            case 2:
            this.PleerMedia = ((System.Windows.Controls.MediaElement)(target));
            return;
            case 3:
            this.StackPanelWithElements = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            
            #line 12 "..\..\WindowVideoPlayer.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.backFromVideoPlayer);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 15 "..\..\WindowVideoPlayer.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.stopThisVideo);
            
            #line default
            #line hidden
            return;
            case 6:
            this.VideoSlider = ((System.Windows.Controls.Slider)(target));
            
            #line 18 "..\..\WindowVideoPlayer.xaml"
            this.VideoSlider.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ChangeValueOfVideoSlider);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 19 "..\..\WindowVideoPlayer.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.continueVideoPlayer);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

