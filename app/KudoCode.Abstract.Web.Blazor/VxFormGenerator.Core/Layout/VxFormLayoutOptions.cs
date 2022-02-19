using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VxFormGenerator.Core.Layout
{
    public class VxFormLayoutOptions
    {
        /// <summary>
        /// Set the label position for the form
        /// </summary>
        public LabelOrientation LabelOrientation { get; set; } = LabelOrientation.LEFT;
        /// <summary>
        /// Set the placeholder policy for the form
        /// </summary>
        public PlaceholderPolicy ShowPlaceholder { get; set; } = PlaceholderPolicy.IMPLICIT_LABEL_FALLBACK;
        /// <summary>
        /// Set the trigger for showing valdidation state
        /// </summary>
        public VisualFeedbackValidationPolicy VisualValidationPolicy { get; set; } = VisualFeedbackValidationPolicy.VALID_AND_INVALID;
    }
}
