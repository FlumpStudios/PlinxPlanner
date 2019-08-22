using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlinxPlanner.Common.Models
{
    public class DefaultContent
    {
        [Key]
        public int DefaultContentId { get; set; }
        public string IntroTitle { get; set; }
        public string IntroText { get; set; }
        public string AboutSection { get; set; }
        public IEnumerable<DefaultSkills> DefaultSkills { get; set; }
        public IEnumerable<DefaultComments> DefaultComments { get; set; }
        public IEnumerable<DefaultPortfolio> DefaultPortfolio { get; set; }
        public IEnumerable<DefaultExperiance> DefaultExperiance { get; set; }
        public string Footer { get; set; }
    }

    public class DefaultSkills
    {
        [Key]
        public int DefaultSkillsId { get; set; }
        public int DefaultContentId { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }

    public class DefaultComments
    {
        [Key]
        public int DefaultCommentsId { get; set; }
        public int DefaultContentId { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }

    public class DefaultPortfolio
    {
        [Key]
        public int DefaultPortFolioId { get; set; }
        public int DefaultContentId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Link { get; set; }
        public string ImageSrc { get; set; }
    }

    public class DefaultExperiance
    {
        [Key]
        public int DefaultExperianceId { get; set; }
        public int DefaultContentId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string JobTitle { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }
    }
}
