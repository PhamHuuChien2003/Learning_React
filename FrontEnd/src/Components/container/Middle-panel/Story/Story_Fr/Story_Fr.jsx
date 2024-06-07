import { useState } from 'react'


import './Story_Fr.css'
import "./Create_Story.css"


import { DataStoryFr } from './dataStoryFr'


export default function StoryFr() {

    const [index, setIndex] = useState(0);
    
    const ListStory1 = [
        <div className="story-create">
            <div className="poc">
                <img src="./images/avt/selfpic.jpg" alt="self pic" />   
            </div>
            <span className="plus-icon">
                <svg xmlns="http://www.w3.org/2000/svg" height="16" width="16" viewBox="0 0 512 512"><path fill="#005eff" d="M256 512A256 256 0 1 0 256 0a256 256 0 1 0 0 512zM232 344V280H168c-13.3 0-24-10.7-24-24s10.7-24 24-24h64V168c0-13.3 10.7-24 24-24s24 10.7 24 24v64h64c13.3 0 24 10.7 24 24s-10.7 24-24 24H280v64c0 13.3-10.7 24-24 24s-24-10.7-24-24z"/></svg>
            </span>
            <span className="name-create-str"> Create story</span>
        </div>
    ];
    
    const ListStory2 = DataStoryFr.map(DataStoryFr =>
        <div className="story">
            <img src={DataStoryFr.srcstr1} alt={DataStoryFr.alt1} />
            <div className="avt-in-str-set">
                <img src={DataStoryFr.srcavtstr1} alt={DataStoryFr.alt2} />
            </div>
            <div className="name"><p>{DataStoryFr.name}</p></div>
        </div>
    );

    var ListStory= ([...ListStory1,...ListStory2]);

    let hasPrev = index > 0;
    let hasNext = index < DataStoryFr.length-3;
    function handleNextClick() {
        if (hasNext) {setIndex(index + 1);} ; 
    };
    function handlePrevClick() {
        if (hasPrev) {setIndex(index - 1);};
    };

    let StoryList1 = ListStory[index];
    let StoryList2 = ListStory[index+1];
    let StoryList3 = ListStory[index+2];
    let StoryList4 = ListStory[index+3];

    return(
        <>
            {StoryList1}
            {StoryList2}
            {StoryList3}
            {StoryList4}
            
            { hasNext &&
                <button onClick={handleNextClick} className="btn1">
                    <svg xmlns="http://www.w3.org/2000/svg" height="16" width="10" viewBox="0 0 320 512"><path d="M310.6 233.4c12.5 12.5 12.5 32.8 0 45.3l-192 192c-12.5 12.5-32.8 12.5-45.3 0s-12.5-32.8 0-45.3L242.7 256 73.4 86.6c-12.5-12.5-12.5-32.8 0-45.3s32.8-12.5 45.3 0l192 192z"/></svg>
                </button>
            }

            { hasPrev &&
                <button onClick={handlePrevClick} className="btn2">
                    <svg xmlns="http://www.w3.org/2000/svg" height="16" width="10" viewBox="0 0 320 512"><path d="M9.4 233.4c-12.5 12.5-12.5 32.8 0 45.3l192 192c12.5 12.5 32.8 12.5 45.3 0s12.5-32.8 0-45.3L77.3 256 246.6 86.6c12.5-12.5 12.5-32.8 0-45.3s-32.8-12.5-45.3 0l-192 192z"/></svg>
                </button>
            }
        </>
    )
}