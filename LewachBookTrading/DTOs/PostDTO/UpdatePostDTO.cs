﻿namespace LewachBookTrading.DTOs.PostDTO
{
    public class UpdatePostDTO
    {
        public int Id { get; set; }
        public string? Description { get; set; }

        //public User? PostedBy { get; set; }


        //public int? PostedById { get; set; }
        public string? Title { get; set; }

        //public DateTime? CreatedDate { get; set; } 

        public string? Location { get; set; }

        //public List<Comment>? Comments { get; set; }


        public List<PhotosDTO>? Photos { get; set; }


        //public List<Like>? Likes { get; set; }
    }
}
