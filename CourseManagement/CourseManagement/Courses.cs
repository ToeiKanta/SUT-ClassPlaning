using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
/*
"Name": "COMPUTER PROGRAMMING I",
  "Credit": "2 (1-3-5)",
  "Groups": {
    "1": {
      "0": {
        "Date": "อังคาร",
        "Time": "10:00-11:00",
        "Room": "B1127",
        "Building": "B"
      },
      "1": {
        "Date": "พฤหัสบดี",
        "Time": "13:00-16:00",
        "Room": "Lab Com ",
        "Building": "B2"
      },
      "Detail": "อาจารย์:  ผู้ช่วยศาสตราจารย์ ดร.คะชา ชาญศิลป์\r\n นางสาวสาวิตรี กวางษี\r\n นายปรัชญ์ พงษ์พานิช\r\n\r\nสอบกลางภาค:   21 ก.ย. 2561 เวลา 15:00 - 16:00 อาคาร B ห้อง B1117  21 ก.ย. 2561 เวลา 15:00 - 16:00 อาคาร B ห้อง B1119สอบประจำภาค:   6 พ.ย. 2561 เวลา 13:00 - 16:00 อาคาร B ห้อง N"
    },
    "2": {
      "0": {
        "Date": "อังคาร",
        "Time": "10:00-11:00",
        "Room": "B1127",
        "Building": "B"
      },
      "1": {
        "Date": "พฤหัสบดี",
        "Time": "13:00-16:00",
        "Room": "Lab Com ",
        "Building": "B2"
      },
      "Detail": "อาจารย์:  ผู้ช่วยศาสตราจารย์ ดร.คะชา ชาญศิลป์\r\n นายปฏิภาณ สิทธิคุณ\r\n นางปราณี กฐินใหม่\r\n นายปริวรรต พุทธมาตย์\r\n\r\nสอบกลางภาค:   21 ก.ย. 2561 เวลา 15:00 - 16:00 อาคาร B ห้อง B1117  21 ก.ย. 2561 เวลา 15:00 - 16:00 อาคาร B ห้อง B1119สอบประจำภาค:   6 พ.ย. 2561 เวลา 13:00 - 16:00 อาคาร B ห้อง N"
    },
 
     */
namespace CourseManagement
{

    public partial class Courses
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Credit")]
        public string Credit { get; set; }

        [JsonProperty("Groups")]
        public Dictionary<string, Group> Groups { get; set; }
    }

    public partial class Group
    {
        [JsonProperty("0", NullValueHandling = NullValueHandling.Ignore)]
        public The0 The0 { get; set; }

        [JsonProperty("1", NullValueHandling = NullValueHandling.Ignore)]
        public The0 The1 { get; set; }

        [JsonProperty("3", NullValueHandling = NullValueHandling.Ignore)]
        public The0 The2 { get; set; }

        [JsonProperty("4", NullValueHandling = NullValueHandling.Ignore)]
        public The0 The3 { get; set; }

        [JsonProperty("Detail")]
        public string Detail { get; set; }
    }

    public partial class The0
    {
        [JsonProperty("Date")]
        public string Date { get; set; }

        [JsonProperty("Time")]
        public string Time { get; set; }

        [JsonProperty("Room")]
        public string Room { get; set; }

        [JsonProperty("Building")]
        public string Building { get; set; }
    }



}
