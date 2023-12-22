import './post_content.css'

export default function Content(Topx) {

    const WordOnly=() => (
        <div class="post-content">
                <div class="bg-ct">
                    <p>
                        <b>{Topx.para1}</b>
                    </p>
                    <p>
                        <b>{Topx.para2}</b>
                    </p>
                    <br/>
                </div>
            </div>
    );

    const SinglepicWithCap=() =>(
        <div class="post-content">
                <p class="cap">{Topx.cap}</p>
                <p class="hashtag">{Topx.hastag}</p>
                <img src={Topx.src_pic_content1} alt="pic"/>
            </div>
    );

    const Vids=()=>(
        <div class="post-content">
                <p>{Topx.cap}</p>
                <video  width="480" height="270" controls autoplay>
                    <source src={Topx.src_vid} type="video/mp4"/>
                </video>  
            </div>
    );

    const Album=()=>(
        <div class="post-content">
                <div class="bg-ct">
                    <p>{Topx.cap}</p>
                    <p class="hashtag">{Topx.hastag}</p>
                    <div class="album-img">
                        <div class="i2-img-ln-1">
                            <div class="img-1-album"> 
                                <img src={Topx.src_pic_content1} alt="p1a"/>
                            </div>
                            <div class="img-2-album"> 
                                <img src={Topx.src_pic_content2} alt="p2a"/>
                            </div>
                        </div>

                        <div class="i3-img-ln-2">
                            <div class="img-3-album"> 
                                <img src={Topx.src_pic_content3} alt="p3a"/>
                            </div>
                            <div class="img-4-album"> 
                                <img src={Topx.src_pic_content4} alt="p4a"/>
                            </div>
                            <div class="img-5-album"> 
                                <img src={Topx.src_pic_content5} alt="p5a"/>
                            </div>
                            <div class="blur-more-img">
                                <p>+{Topx.num_p}</p>
                            </div> 
                        </div>                       
                    </div>
                    <br/>
                </div>
            </div>
    );
    

    const Vote=()=>(

        <div class="post-content">
                <p>{Topx.cap}</p>
                <div class="Vote-sections">
                    <ul>
                        <li>
                            <div class="vote">
                                <div class="percent-voted-1"></div>
                                <div class="square-choose">
                                    <div class="setting-check-mark">
                                        <input type="checkbox"/>
                                    </div>
                                </div>
                                <div class="name-1st-choice"><span class="name-choice-1"><b>{Topx.name_choice_1}</b></span></div>
                                <div class="result-percent-voted">
                                    <span>{Topx.percent_1}</span>
                                    <i class="fa-solid fa-chevron-right" style={{color:"#6b6b6b"}}></i>
                                </div>
                            </div>
                        </li>
                        <li>
                            <div class="vote">
                                <div class="percent-voted-2"></div>
                                <div class="square-choose">
                                    <div class="setting-check-mark">
                                        <input type="checkbox"/>
                                    </div>
                                </div>
                                <div class="name-2nd-choice">
                                    <span class="added-by">Added by <b>{Topx.Added_by_2}</b></span>
                                    <span class="name-choice"><b>{Topx.name_choice_2}</b></span>
                                </div>
                                <div class="result-percent-voted">
                                    <span>{Topx.percent_2}</span>
                                    <i class="fa-solid fa-chevron-right" style={{color: "#6b6b6b"}}></i>
                                </div>
                            </div>
                        </li>
                        <li>
                            <div class="vote">
                                <div class="percent-voted-3"></div>
                                <div class="square-choose">
                                    <div class="setting-check-mark">
                                        <input type="checkbox"/>
                                    </div>
                                </div>
                                <div class="name-3rd-choice">
                                    <span class="added-by">Added by <b>{Topx.Added_by_3}</b></span>
                                    <span class="name-choice"><b>{Topx.name_choice_3}</b></span>
                                </div>
                                <div class="result-percent-voted">
                                    <span>{Topx.percent_3}</span>
                                    <i class="fa-solid fa-chevron-right" style={{color: "#6b6b6b"}}></i>
                                </div>

                            </div>
                        </li>
                        <li>
                            <div class="vote">
                                <div class="percent-voted-4"></div>
                                <div class="square-choose">
                                    <div class="setting-check-mark">
                                        <input type="checkbox"/>
                                    </div>
                                </div>
                                <div class="name-4th-choice">
                                    <span class="added-by">Added by <b>{Topx.Added_by_4}</b></span>
                                    <span class="name-choice"><b>{Topx.name_choice_4}</b></span>
                                </div>
                                <div class="result-percent-voted">
                                    <span>{Topx.percent_4}</span>
                                    <i class="fa-solid fa-chevron-right" style={{color: "#6b6b6b"}}></i>
                                </div>

                            </div>
                        </li>
                        <li>
                            <div class="vote">
                                <div class="percent-voted-5"></div>
                                <div class="square-choose">
                                    <div class="setting-check-mark">
                                        <input type="checkbox"/>
                                    </div>
                                </div>
                                <div class="name-5th-choice">
                                    <span class="added-by">Added by <b>{Topx.Added_by_5}</b></span>
                                    <span class="name-choice"><b>{Topx.name_choice_5}</b></span>
                                </div>
                                <div class="result-percent-voted">
                                    <span>{Topx.percent_5}</span>
                                    <i class="fa-solid fa-chevron-right" style={{color:"#6b6b6b"}}></i>
                                </div>

                            </div>
                        </li>
                    </ul>

                    <div class="see-all-voted">
                        <p>See all (20)</p>
                    </div>
                </div>
            </div>
    );

    let content1;
    
    Topx.ct_type === 'sg-pic' && ( content1 = SinglepicWithCap());
    Topx.ct_type === 'pic_w_vid' && (content1 = Vids() );
    Topx.ct_type === 'album' && (content1 = Album());
    Topx.ct_type === 'vote' && (content1 =  Vote() );
    Topx.ct_type === 'word' && (content1 = WordOnly());

    return (
        <>{content1}</>
    )

}