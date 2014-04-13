﻿using uComponents.DataTypes.UrlPicker.Dto;
using umbraco;
using umbraco.NodeFactory;

namespace MetroBlooms.ViewModels.Sections
{
    public class CallToActionSection : BaseSection
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public UrlPickerState CTA1 { get; set; }
        public UrlPickerState CTA2 { get; set; }
        public string Alignment { get; set; }

        public CallToActionSection(Node node) : base(node)
        {
            if (node == null) return;

            Title = node.GetProperty<string>("title");
            Text = node.GetProperty<string>("text");
            CTA1 = UrlPickerState.Deserialize(node.GetProperty<string>("cta1"));
            CTA2 = UrlPickerState.Deserialize(node.GetProperty<string>("cta2"));
            Alignment = node.GetProperty<string>("Alignment");
        }
    }
}