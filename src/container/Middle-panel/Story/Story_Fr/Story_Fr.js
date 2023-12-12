import './Story_Fr.css'


import { DataStoryFr } from './dataStoryFr'


export default function StoryFr() {
    const ListStory= DataStoryFr.map(DataStoryFr =>
        <div class="story">
            <img src={DataStoryFr.srcstr1} alt={DataStoryFr.alt1} />
            <div class="avt-in-str-set">
                <img src={DataStoryFr.srcavtstr1} alt={DataStoryFr.alt2} />
            </div>
            <div class="name"><p>{DataStoryFr.name}</p></div>
        </div>
    )

    return(
            {ListStory}
    )
}