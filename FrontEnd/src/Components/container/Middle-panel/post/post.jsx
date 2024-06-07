import "./post.css";

import { DataPost } from "./datapost";

import Top from "./post_top/post_top";
import PostBot from "./post_bot/post_bot";
import Content from "./post_content/post_content";
import Cmt from "./cmt_post/cmt";
import { useQueryFetchPost } from "../../../../Hooks/FetchApi/useQueryFetchPost";
import { useState } from "react";

export default function Post() {

  const [postPageParam,setpostPageParam] = useState(0);
  
  const DataPost1=useQueryFetchPost(postPageParam);



  const ListPost = DataPost.map((post) => (
    <div className="post">
      <Top {...post} />
      <Content {...post} />
      <PostBot {...post} />
      <Cmt {...post}  />
    </div>
  ));

  return ( <>{ ListPost }</>);
}
