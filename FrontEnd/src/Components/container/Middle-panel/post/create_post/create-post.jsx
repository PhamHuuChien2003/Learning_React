import './create-post.css'

export default function CreatePost() {

    return (
        <div className="post-create">

            <div className="post-top">
                <div className="avt-person-post">
                    <img src="./images/avt/selfpic.jpg" alt="self pic"/>
                </div>
                <input type="text" placeholder="What's on your mind, Chiến ?"/>
            </div>

            <hr className="line"/>

            <div className="post-create-bot">
                <div className="button-below-post-create">
                    <img src="./icon/Live-video.png" alt=""/>
                    <span>Live video</span>
                </div>
                <div className="button-below-post-create">
                    <img src="./icon/Anh-video.png" alt=""/>
                    <span>Photo/video</span>
                </div>
                <div className="button-below-post-create">
                    <img src="./icon/cam-xuc-hoat-dong.png" alt=""/>
                    <span>Feeling/activity</span>
                </div>
            </div>
        </div>
    )
}