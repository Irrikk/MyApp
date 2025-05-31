using MauiApp1.Source.Sandbox;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MauiApp1
{
    public class NodeEditor
    {
        public NodeEditor(AppContext context)
        {
            IntNode intNode1 = new(
                context: context,
                position: new(50, 50)
            );

            IntNode intNode2 = new IntNode(
                context: context,
                position: new(50, 50)
            );

            BoolNode boolNode = new BoolNode(
                context: context,
                position: new(150, 50)
            );

            DoubleNode doubleNode1 = new(
                context: context,
                position: new(250, 50)
            );

            DoubleNode doubleNode2 = new(
                context: context,
                position: new(250, 50)
            );

            DivNode divNode = new(context, new(50, 150));
            MaxNode maxNode = new(context, new(50, 250));
            MinNode minNode = new(context, new(50, 350));
            MultNode multNode = new(context, new(50, 450));
            SubNode subNode = new(context, new(50, 550));
            SumNode sumNode = new(context, new(50, 650));
            GreaterThanNode gtNode = new(context, new(50, 750));
            OutputNode outputNode = new(context);
            NodeSelector nodeSelector = new(context);
            NodeLinker nodeLinker = new(context);
            LinkDrawer linkDrawer = new(context);
            Runner runner = new(outputNode);
            StartButtonNode startButtonNode = new(context, runner, position: new(500, 500));

            //test
            Border startButton = new()
            {
                HeightRequest = 50,
                WidthRequest = 50,
                TranslationX = 500,
                TranslationY = 500
            };

            TapGestureRecognizer tapGesture = new();
            tapGesture.Tapped += (x, y) => runner.Start();
            startButton.GestureRecognizers.Add(tapGesture);
            context.EventBus.nodeSelected.Subscribe(node => Debug.WriteLine("Click"));
        }
    }
}
