using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoIstProject.Entities.Model
{
    public class AddTaskResponse
    {
        public string id { get; set; }
        public object assigner_id { get; set; }
        public object assignee_id { get; set; }
        public string project_id { get; set; }
        public object section_id { get; set; }
        public object parent_id { get; set; }
        public int order { get; set; }
        public string content { get; set; }
        public string description { get; set; }
        public bool is_completed { get; set; }
        public List<string> labels { get; set; }
        public int priority { get; set; }
        public int comment_count { get; set; }
        public string creator_id { get; set; }
        public DateTime created_at { get; set; }
        public Due due { get; set; }
        public string url { get; set; }
    }
    public class Due
    {
        public string date { get; set; }
        public string @string { get; set; }
        public string lang { get; set; }
        public bool is_recurring { get; set; }
    }
}
