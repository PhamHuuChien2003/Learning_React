import './Middle-panel.css'


import Story from './Story/Story'
import CreatePost from './post/create_post/create-post'
import Post from './post/post'


export default function MiddlePanel() {

    return(
        <div className="middle-panel">
            <Story/>
            <CreatePost/>
            <Post/>
        </div>
    )
}