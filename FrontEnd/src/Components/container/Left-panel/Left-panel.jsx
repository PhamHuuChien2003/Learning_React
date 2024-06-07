import "./Left-panel.css"
import { dataLeftpanel1 } from "./data-1-Left-panel"
import { dataLeftpanel2 } from "./data-2-Left-panel"

import { useState } from 'react'

export default function LeftPanel() {



    var List_left_panel11 = dataLeftpanel1.filter(dataLeftpanel1=>dataLeftpanel1.id<6);
    var List_left_panel12 = dataLeftpanel1.filter(dataLeftpanel1=>dataLeftpanel1.id<15);

    const [list1, setList1] =useState([...List_left_panel11]);
    let seemore1 = list1.length < 6;
    let seeless1=list1.length>5;
    // setList1([...List_left_panel11]);
    function handleSeemore1() {
        if (seemore1) {setList1([...List_left_panel12])}
    };
    function handleSeeless1() {
        if (seeless1) { setList1([...List_left_panel11])}
    };

    var List_icon_Left_panel_1 =  list1.map(list1 =>
        <li key={list1.id}>
           <img src={list1.src} alt={list1.alt}></img>
           <p><b>{list1.name}</b></p>
        </li>
    );
 

    var List_left_panel21 = dataLeftpanel2.filter(dataLeftpanel2=>dataLeftpanel2.id<6);
    var List_left_panel22 = dataLeftpanel2.filter(dataLeftpanel2=> dataLeftpanel2.id<10);

    
    const [list2, setList2] =useState([...List_left_panel21]);
    let seemore2 = list2.length < 6;
    let seeless2=list2.length>5;
    // list2=[...List_left_panel21];
    function handleSeemore2() {
        if (seemore2) {setList2([...List_left_panel22])}
    };
    function handleSeeless2() {
        if (seeless2) { setList2([...List_left_panel21])}
    };
    
    var List_icon_Left_panel_2 =  list2.map(list2 =>
        <li key={list2.id}>
           <img src={list2.src} alt={list2.alt}></img>
           <p><b>{list2.name}</b></p>
        </li>
    );

    
    return(
    <>
    <div className="left-panel">
        <div className="left-panel-but" >
            <ul>
                <li>
                    <span className="profile" style={{ backgroundImage: `url("./images/avt/selfpic.jpg")`}}></span>
                    <p><b>Phạm Hữu Chiến</b></p>
                </li>
            </ul>
            <ul>{List_icon_Left_panel_1}</ul>
            <ul>
                <li>
                    { seemore1 &&
                        <button onClick={handleSeemore1}>
                            <div className="see-more">
                                <div className="down-chn"><a href="#"><i className="fa-solid fa-chevron-down"></i></a></div>
                                <p><b>See more</b></p>
                            </div>
                        </button>
                    }
                    { seeless1 &&
                        <button onClick={handleSeeless1}>
                            <div className="see-more">
                                <div className="down-chn"><a href="#"><i className="fa-solid fa-chevron-up"></i></a></div>
                                <p><b>See more</b></p>
                            </div>
                        </button>
                    }                 
                </li>
                <hr className="line"></hr>
                <li>  
                    <div className="ur-sc"><p><b>Your shotcut</b></p></div>
                </li>
            </ul>
            <ul>{List_icon_Left_panel_2}</ul>
            <ul>
                <li>
                    { seemore2 &&
                        <button onClick={handleSeemore2}>
                            <div className="see-more">
                                <div className="down-chn"><a href="#"><i className="fa-solid fa-chevron-down"></i></a></div>
                                <p><b>See more</b></p>
                            </div>
                        </button>
                    } 
                    { seeless2 &&
                        <button onClick={handleSeeless2}>
                            <div className="see-more">
                                <div className="down-chn"><a href="#"><i className="fa-solid fa-chevron-up"></i></a></div>
                                <p><b>See less</b></p>
                            </div> 
                        </button>
                    }
                </li>
            </ul>
        </div>
        {/* <div className="links">
            <div className="c4">
                <p>Privacy</p> <span className="dot">.</span>
                <p>Terms</p> <span className="dot">.</span>
                <p>Advertising</p> <span className="dot">.</span>
                <p>Ad Choice</p>
            </div>  
            <div className="c3l">  
                <p>Cookies</p> <span className="dot">.</span>
                <p>More</p> <span className="dot">.</span>
                <p>Meta c 2023</p> 
            </div>
        </div> */}
    </div>
    </>
    )
}