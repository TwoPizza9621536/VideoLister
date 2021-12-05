// SPDX-FileCopyrightText: Copyright (c) 2021, Samuel Wu
//
// SPDX-License-Identifier: BSD-3-Clause
namespace VideoLister
{
    /// <summary>
    /// Video class with title and id.
    /// </summary>
    public class Video
    {
        public string Id;
        public string Title;

        public Video(string VideoTitle, string VideoID)
        {
            Title = VideoTitle;
            Id = VideoID;
        }
    }
}
