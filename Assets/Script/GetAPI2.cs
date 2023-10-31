using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAPI2 : MonoBehaviour
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class A
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string video_url { get; set; }
        public string thumbnail_url { get; set; }
    }

    public class C
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public object url_file { get; set; }
        public Image image { get; set; }
    }

    public class Formats
    {
        public Thumbnail thumbnail { get; set; }
        public Large large { get; set; }
        public Medium medium { get; set; }
        public Small small { get; set; }
    }

    public class Image
    {
        public int id { get; set; }
        public string name { get; set; }
        public string alternativeText { get; set; }
        public string caption { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public Formats formats { get; set; }
        public string hash { get; set; }
        public string ext { get; set; }
        public string mime { get; set; }
        public double size { get; set; }
        public string url { get; set; }
        public object previewUrl { get; set; }
        public string provider { get; set; }
        public object provider_metadata { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class Large
    {
        public string name { get; set; }
        public string hash { get; set; }
        public string ext { get; set; }
        public string mime { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public double size { get; set; }
        public object path { get; set; }
        public string url { get; set; }
    }

    public class Medium
    {
        public string name { get; set; }
        public string hash { get; set; }
        public string ext { get; set; }
        public string mime { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public double size { get; set; }
        public object path { get; set; }
        public string url { get; set; }
    }

    public class Root
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime published_at { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public List<A> A { get; set; }
        public List<C> C { get; set; }
        public List<object> E { get; set; }
    }

    public class Small
    {
        public string name { get; set; }
        public string hash { get; set; }
        public string ext { get; set; }
        public string mime { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public double size { get; set; }
        public object path { get; set; }
        public string url { get; set; }
    }

    public class Thumbnail
    {
        public string name { get; set; }
        public string hash { get; set; }
        public string ext { get; set; }
        public string mime { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public double size { get; set; }
        public object path { get; set; }
        public string url { get; set; }
    }


}
