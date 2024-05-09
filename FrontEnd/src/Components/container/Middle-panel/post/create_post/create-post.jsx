import './create-post.css'

export default function CreatePost() {

    return (
        <div class="post-create">

            <div class="post-top">
                <div class="avt-person-post">
                    <img src="./images/avt/selfpic.jpg" alt="self pic"/>
                </div>
                <input type="text" placeholder="What's on your mind, Chiến ?"/>
            </div>

            <hr class="line"/>

            <div class="post-create-bot">
                <div class="button-below-post-create">
                    <img src="./icon/Live-video.png" alt=""/>
                    <span>Live video</span>
                </div>
                <div class="button-below-post-create">
                    <img src="./icon/Anh-video.png" alt=""/>
                    <span>Photo/video</span>
                </div>
                <div class="button-below-post-create">
                    <img src="./icon/cam-xuc-hoat-dong.png" alt=""/>
                    <span>Feeling/activity</span>
                </div>
            </div>
        </div>
    )
}