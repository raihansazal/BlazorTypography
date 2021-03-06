﻿namespace BlazorTypography.Plugins
{
    public class CodePlugn : IPlugin
    {
        public string Title => "Code";
        public void Run(Styles styles, ITypographyOptions options, VerticalRhythm vr)
        {
            string rhythm1 = vr.Rhythm(1);
            string blockMarginBottom;
            if (float.TryParse(options.BlockMarginBottom, out float result))
            {
                blockMarginBottom = vr.Rhythm(result);
            }
            else if (!string.IsNullOrWhiteSpace(options.BlockMarginBottom))
            {
                blockMarginBottom = options.BlockMarginBottom;
            }
            else
            {
                blockMarginBottom = rhythm1;
            }

            styles.Add("tt,code", $@"
                    background-color: {vr.Gray(96)};
                    border-radius: 3px;
                    font-family: ""SFMono - Regular"", Consolas, ""Roboto Mono"" ,""Droid Sans Mono"", ""Liberation Mono"", Menlo, Courier, monospace;
                    padding: 0;
                    padding-top: 0.2em;
                    padding-bottom: 0.2em;
                ");
            styles.Add("pre", $@"
                    background: {vr.Gray(96)};
                    border-radius: 3px;
                    line-height: 1.42;
                    overflow: auto;
                    word-wrap: normal;
                    padding: {blockMarginBottom};
                ");
            styles.Add("pre code", @"
                    background: none;
                    line-height: 1.42;
                ");
            styles.Add("code:before,code:after,tt:before,tt:after", @"
                    letter-spacing: -0.2em;
                    content: "" "";
                ");
            styles.Add("pre code:before,pre code:after,pre tt:before,pre tt:after", @"
                    content: none;
                ");
        }
    }
}
