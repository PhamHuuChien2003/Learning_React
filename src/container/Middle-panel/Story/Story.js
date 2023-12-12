import './Story.css'

import StoryFr from './Story_Fr/Story_Fr'   
import CreateStory from './Create_Story/Create_Story'


export default function Story() {

    return(
        <div class="story-section">
            <CreateStory/>
            <StoryFr/>
        </div>
    )
}