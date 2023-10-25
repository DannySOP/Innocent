using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GetAPI : MonoBehaviour
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Attributes
    {
        public string title { get; set; }
        public string description { get; set; }
        public string slug { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime publishedAt { get; set; }
        public List<Block> blocks { get; set; }
        public string name { get; set; }
        public object alternativeText { get; set; }
        public string url { get; set; }
    }

    public class Block
    {
        public int id { get; set; }
        public string __component { get; set; }
        public string heading { get; set; }
        public string text { get; set; }
        public Link link { get; set; }
        public string description { get; set; }
        public Image image { get; set; }
        public List<Card> card { get; set; }
        public string name { get; set; }
        public List<Plan> plan { get; set; }
        public string title { get; set; }
    }

    public class Card
    {
        public int id { get; set; }
        public string heading { get; set; }
        public string description { get; set; }
        public Images images { get; set; }
    }

    public class Data
    {
        public int id { get; set; }
        public Attributes attributes { get; set; }
    }

    public class Image
    {
        public Data data { get; set; }
    }

    public class Images
    {
        public Data data { get; set; }
    }

    public class Link
    {
        public int id { get; set; }
        public string title { get; set; }
        public string link { get; set; }
        public bool isExternal { get; set; }
        public string type { get; set; }
    }

    public class Meta
    {
        public Pagination pagination { get; set; }
    }

    public class Pagination
    {
        public int page { get; set; }
        public int pageSize { get; set; }
        public int pageCount { get; set; }
        public int total { get; set; }
    }

    public class Plan
    {
        public int id { get; set; }
        public string planType { get; set; }
        public string planDescription { get; set; }
        public string planPrice { get; set; }
        public bool isFeatured { get; set; }
        public Services services { get; set; }
        public Link link { get; set; }
    }

    public class Root
    {
        public List<Data> data { get; set; }
        public Meta meta { get; set; }
    }

    public class Services
    {
        public List<Data> data { get; set; }
    }
}
