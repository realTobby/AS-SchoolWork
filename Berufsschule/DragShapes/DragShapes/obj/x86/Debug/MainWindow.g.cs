﻿#pragma checksum "..\..\..\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "244CAA333028A8F0AE15AB1AE4DB259B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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


namespace DragShapes {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 5 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas LayoutRoot;
        
        #line default
        #line hidden
        
        
        #line 6 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse testEllipse;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle testSquare;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DragShapes;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.LayoutRoot = ((System.Windows.Controls.Canvas)(target));
            return;
            case 2:
            this.testEllipse = ((System.Windows.Shapes.Ellipse)(target));
            
            #line 6 "..\..\..\MainWindow.xaml"
            this.testEllipse.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.shape_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 6 "..\..\..\MainWindow.xaml"
            this.testEllipse.MouseMove += new System.Windows.Input.MouseEventHandler(this.shape_MouseMove);
            
            #line default
            #line hidden
            
            #line 6 "..\..\..\MainWindow.xaml"
            this.testEllipse.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.shape_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.testSquare = ((System.Windows.Shapes.Rectangle)(target));
            
            #line 7 "..\..\..\MainWindow.xaml"
            this.testSquare.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.shape_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 7 "..\..\..\MainWindow.xaml"
            this.testSquare.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.shape_MouseLeftButtonUp);
            
            #line default
            #line hidden
            
            #line 7 "..\..\..\MainWindow.xaml"
            this.testSquare.MouseMove += new System.Windows.Input.MouseEventHandler(this.shape_MouseMove);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

