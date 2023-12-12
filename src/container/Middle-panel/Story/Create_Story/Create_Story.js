import "./Create_Story.css"

export default function CreateStory() {


    return(
        <div class="story-create">
                <div class="poc">
                    <img src="./images/avt/selfpic.jpg" alt="self pic" />   
                </div>
                <span class="plus-icon">
                    <svg xmlns="http://www.w3.org/2000/svg" height="16" width="16" viewBox="0 0 512 512"><path fill="#005eff" d="M256 512A256 256 0 1 0 256 0a256 256 0 1 0 0 512zM232 344V280H168c-13.3 0-24-10.7-24-24s10.7-24 24-24h64V168c0-13.3 10.7-24 24-24s24 10.7 24 24v64h64c13.3 0 24 10.7 24 24s-10.7 24-24 24H280v64c0 13.3-10.7 24-24 24s-24-10.7-24-24z"/></svg>
                </span>
                <span class="name-create-str"> Create story</span>
            </div>
    )
}