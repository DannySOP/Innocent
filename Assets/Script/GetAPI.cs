using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static WebRequest;

public class GetAPI : MonoBehaviour
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Attributes
    {
        public string description { get; set; }
        public string title { get; set; }
        public string slug { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime publishedAt { get; set; }
        public Metadata metadata { get; set; }
        public List<Block> blocks { get; set; }
        public string name { get; set; }
        public object alternativeText { get; set; }
        public string url { get; set; }
    }

    public class Block
    {
        public int id { get; set; }
        public string __component { get; set; }
        public string description { get; set; }
        public string title { get; set; }
        public Link link { get; set; }
        public List<Card> card { get; set; }
        public List<Library> library { get; set; }
        public string descriiption { get; set; }
        public Image image { get; set; }
    }

    public class Card
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Image image { get; set; }
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

    public class Library
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Image image { get; set; }
    }

    public class Link
    {
        public int id { get; set; }
        public string content { get; set; }
        public bool isExternal { get; set; }
        public string type { get; set; }
    }

    public class Meta
    {
        public Pagination pagination { get; set; }
    }

    public class Metadata
    {
        public int id { get; set; }
        public string metaTitle { get; set; }
        public string metaDescription { get; set; }
        public MetaImage metaImage { get; set; }
    }

    public class MetaImage
    {
        public List<DataMap> data { get; set; }
    }

    public class Pagination
    {
        public int page { get; set; }
        public int pageSize { get; set; }
        public int pageCount { get; set; }
        public int total { get; set; }
    }

    public class Root
    {
        public List<DataMap> data { get; set; }
        public Meta meta { get; set; }
    }


}
