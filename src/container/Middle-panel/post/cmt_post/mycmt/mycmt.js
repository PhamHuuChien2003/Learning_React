import './mycmt.css'

export default function MyCmt() {

    const style1 = {
        'background-Image': 'url(&quot;https://static.xx.fbcdn.net/rsrc.php/v3/yE/r/FA22Qd7z224.png&quot;)',
        'background-position': '0px -1130px',
        'background-size': '26px 1572px',
        'width': '16px',
        'height': '16px',
        'background-repeat': 'no-repeat', 
        'display': 'inline-block',
    }
    const style2 = {
        'background-Image': 'url(&quot;https://static.xx.fbcdn.net/rsrc.php/v3/yE/r/FA22Qd7z224.png&quot;)',
        'background-position': '0px -1274px',
        'background-size': '26px 1572px',
        'width': '16px',
        'height': '16px',
        'background-repeat': 'no-repeat', 
        'display': 'inline-block',
    }
    const style3 = {
        'background-Image': 'url(&quot;https://static.xx.fbcdn.net/rsrc.php/v3/yE/r/FA22Qd7z224.png&quot;)',
        'background-position': '0px -1202px',
        'background-size': '26px 1572px',
        'width': '16px',
        'height': '16px',
        'background-repeat': 'no-repeat', 
        'display': 'inline-block',
    }
    const style4 = {
        'background-Image': 'url(&quot;https://static.xx.fbcdn.net/rsrc.php/v3/yE/r/FA22Qd7z224.png&quot;)',
        'background-position': '0px -1310px',
        'background-size': '26px 1572px',
        'width': '16px',
        'height': '16px',
        'background-repeat': 'no-repeat', 
        'display': 'inline-block',
    }
    const style5= {
        'backgroundImage': 'url(&quot;https://static.xx.fbcdn.net/rsrc.php/v3/yE/r/FA22Qd7z224.png&quot;)',
        'background-position': '0px -1454px',
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
                                        <i data-visualcompletion="css-img" class="x1b0d499 x1d69dk1" style={{backgroundImage: `url(&quot;https://static.xx.fbcdn.net/rsrc.php/v3/yE/r/FA22Qd7z224.png&quot;)`,...style1}}></i>
                                    </li>
                                </ul>
                                <ul>
                                    <li>
                                        <i data-visualcompletion="css-img" class="x1b0d499 x1d69dk1" style={{backgroundImage: `url(&quot;https://static.xx.fbcdn.net/rsrc.php/v3/yE/r/FA22Qd7z224.png&quot;)`,...style2}}></i>
                                    </li>
                                </ul>
                                <ul>
                                    <li>
                                        <i data-visualcompletion="css-img" class="x1b0d499 x1d69dk1" style={{backgroundImage: `url(&quot;https://static.xx.fbcdn.net/rsrc.php/v3/yE/r/FA22Qd7z224.png&quot;)`,...style3}}></i>
                                    </li>
                                </ul>
                                <ul>
                                    <li>
                                        <i data-visualcompletion="css-img" class="x1b0d499 x1d69dk1" style={{backgroundImage: `url(&quot;https://static.xx.fbcdn.net/rsrc.php/v3/yE/r/FA22Qd7z224.png&quot;)`,...style4}}></i>
                                    </li>
                                </ul>
                                <ul>
                                    <li>
                                        <i data-visualcompletion="css-img" class="x1b0d499 x1d69dk1" style={{backgroundImage: `url(&quot;https://static.xx.fbcdn.net/rsrc.php/v3/yE/r/FA22Qd7z224.png&quot;)`,...style5}}></i>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
    )
}