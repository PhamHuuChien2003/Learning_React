import './mycmt.css'

export default function MyCmt() {

    const style1 = {
        'background-position': '0px -1143.5px',
        'background-size': '26px 1550px',
        'width': '16px',
        'height': '16px',
        'background-repeat': 'no-repeat', 
        'display': 'inline-block',
    }
    const style2 = {
        'background-position': '0px -1270px',
        'background-size': '26px 1572px',
        'width': '16px',
        'height': '16px',
        'background-repeat': 'no-repeat', 
        'display': 'inline-block',
    }
    const style3 = {
        'background-position': '0px -1197px',
        'background-size': '26px 1572px',
        'width': '16px',
        'height': '16px',
        'background-repeat': 'no-repeat', 
        'display': 'inline-block',
    }
    const style4 = {
        'background-position': '0px -1308px',
        'background-size': '26px 1572px',
        'width': '16px',
        'height': '16px',
        'background-repeat': 'no-repeat', 
        'display': 'inline-block',
    }
    
    const style5= {
        'background-position': '0px -1437px',
        'background-size': '26px 1572px',
        'width': '16px',
        'height': '16px',
        'background-repeat': 'no-repeat', 
        'display': 'inline-block',
    }


    return(
        <div class="my-cmt-section">
                        <div class="my-avt-in-cmt">
                            <img src="./images/avt/selfpic.jpg" alt=""/>
                            <div class="chevron-down" style={{'background-color': 'var(--secondary-button-background)'}}>
                                <svg viewBox="0 0 16 16" width="1em" height="1em" fill="currentColor" class="chevron-down-svg">
                                    <g fill-rule="evenodd" transform="translate(-448 -544)">
                                        <path fill-rule="nonzero" d="M452.707 549.293a1 1 0 0 0-1.414 1.414l4 4a1 1 0 0 0 1.414 0l4-4a1 1 0 0 0-1.414-1.414L456 552.586l-3.293-3.293z">
                                        </path>
                                    </g>
                                </svg>
                            </div>
                        </div>
                        <div class="input-cmt">
                            <input type="text" placeholder="Write a public comment"/>
                            <div class="cmt-icon-butt">
                                <ul>
                                    <li>
                                        <i data-visualcompletion="css-img" class="x1b0d499 x1d69dk1" style={{backgroundImage: `url("./icon/fullicon.png")`,...style1}}></i>
                                    </li>
                                </ul>
                                <ul>
                                    <li>
                                        <i data-visualcompletion="css-img" class="x1b0d499 x1d69dk1" style={{backgroundImage: `url("./icon/fullicon.png")`,...style2}}></i>
                                    </li>
                                </ul>
                                <ul>
                                    <li>
                                        <i data-visualcompletion="css-img" class="x1b0d499 x1d69dk1" style={{backgroundImage: `url("./icon/fullicon.png")`,...style3}}></i>
                                    </li>
                                </ul>
                                <ul>
                                    <li>
                                        <i data-visualcompletion="css-img" class="x1b0d499 x1d69dk1" style={{backgroundImage: `url("./icon/fullicon.png")`,...style4}}></i>
                                    </li>
                                </ul>
                                <ul>
                                    <li>
                                        <i data-visualcompletion="css-img" class="x1b0d499 x1d69dk1" style={{backgroundImage: `url("./icon/fullicon.png")`,...style5}}></i>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
    )
}