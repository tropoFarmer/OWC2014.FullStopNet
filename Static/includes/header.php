<?php
if (!isset($footerType)) {
    $footerType = '';
}
?>
<div class="site">
    <div class="siteHeader" role="masthead">
        <div class="headerInfo">
            <a class="signIn" href="#">Sign In</a>
            <ul class="navSecondary">
                <li><a href="#">Upcoming Events</a></li>
                <li><a href="#">About Us</a></li>
            </ul>
        </div>
        <div class="headerLower">
            <a class="headerLogo" href="#"><img src="assets/images/logo.png" alt="Metro Blooms"/></a>
            <ul class="nav">
                <li><a href="#"><span class="navTag">Learn about</span> Raingardens</a></li>
                <li><a href="#"><span class="navTag">How to Help</span> Get Involved</a></li>
                <li><a href="#"><span class="navTag">Award Entries</span> Submit a Garden</a></li>
                <li><a href="#"><span class="navTag">Award Judging</span> Evaluate a Garden</a></li>
            </ul>
        </div>
    </div> <!-- /.siteHeader -->
    <div class="siteMain<?php if ($footerType == 'home') {echo " siteMain_home";} ?>" role="main">
