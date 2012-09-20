<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="orgs_Default" %>
<%@ Register TagPrefix="proj" TagName="Header" Src="~/UserControls/Header.ascx" %>
<%@ Register TagPrefix="proj" TagName="Footer" Src="~/UserControls/Footer.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title></title>
    <link rel="Stylesheet" runat="server" href="~/css/saf.css" />

    <script type="text/javascript">
    // Browser Detection
    isMac = (navigator.appVersion.indexOf("Mac")!=-1) ? true : false;
    NS4 = (document.layers) ? true : false;
    IEmac = ((document.all)&&(isMac)) ? true : false;
    IE4plus = (document.all) ? true : false;
    IE4 = ((document.all)&&(navigator.appVersion.indexOf("MSIE 4.")!=-1)) ? true : false;
    IE5 = ((document.all)&&(navigator.appVersion.indexOf("MSIE 5.")!=-1)) ? true : false;
    IE6 = ((document.all)&&(navigator.appVersion.indexOf("MSIE 6.")!=-1)) ? true : false;
    ver4 = (NS4 || IE4plus) ? true : false;
    NS6 = (!document.layers) && (navigator.userAgent.indexOf('Netscape')!=-1)?true:false;

    IE5plus = IE5 || IE6;
    IEMajor = 0;

    if (IE4plus)
    {
	    var start = navigator.appVersion.indexOf("MSIE");
	    var end = navigator.appVersion.indexOf(".",start);
	    IEMajor = parseInt(navigator.appVersion.substring(start+5,end));
	    IE5plus = (IEMajor>=5) ? true : false;
    }
    </script>

    <script type="text/javascript">
        var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
        document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
    </script>
    <script type="text/javascript">
        try {
            var pageTracker = _gat._getTracker("UA-9113157-1");
            pageTracker._trackPageview();
        } catch (err) { }
    </script> 
</head>
<body>
    <noscript>
        This site requires javascript to be completely functional.
    </noscript>

    <form id="form1" runat="server">

        <a href="#nonav" class="assistive">Skip navigation links</a>

        <center>
            <div id="container">	
                <proj:Header ID="header" runat="server" />

	            <!--- Contents --->
	            <div id="content">
    	            <a name="nonav"></a>
	                <!---This is the anchor to the skip navigation it jumps the user to the beginning of the content on the page.--->

                    <asp:Label ID="lblOrgName" runat="server" CssClass="title" />

            		<p class="subtitle">
                        Welcome <asp:Literal ID="litContactName" runat="server" />.	Please select from one of the following.
                    </p>

                    <table cellpadding="0" cellspacing="10" border="0" width="100%">
                    <tr bgcolor="FFFFFF">	
	                    <td width="25%" bgcolor="FFFFFF" valign="top">
		                    <p class="subtitle">
                                Create New Posting<br /><br />
		                        <a href="add_posting.aspx?type=artist" title="Link to Artist Opportunity">Artist Opportunity</a><br />
		                        <a href="add_posting.aspx?type=job" title="Link to Employment Opportunity">Employment Opportunity</a><br />
		                        <a href="add_posting.aspx?type=intern" title="Link to Internship Opportunity">Internship Opportunity</a>
		                    </p>
	                    </td>
	                    <td bgcolor="000000"><img src="../graphics/spacer.gif" width="1" alt="" /></td>
	                    <td width="30%" bgcolor="FFFFFF" valign="top">	
		                    <p class="subtitle">Edit or Delete a Posting</p>

                            <asp:PlaceHolder ID="plcNoListings" runat="server">
			                    <p class="text">You have no postings.</p>
                            </asp:PlaceHolder>

                            <asp:PlaceHolder ID="plcListings" runat="server" Visible="false">
			                    <table width="100%">
			                    <tr>
				                    <td>
                                        <span class="text"><label for="Posting">
					                    * Approved postings<br /></label>
					                    # Deactivated postings<br /></span>
                                        <asp:ListBox ID="lstPostings" runat="server" Rows="5" />
                                        <asp:RequiredFieldValidator ID="reqPostings" runat="server" ErrorMessage="Please select a posting."
                                            ControlToValidate="lstPostings" Display="Dynamic" />
                                        <br />
                                        <asp:Button ID="btnEdit" runat="server" Text="Edit" />
                                        <asp:Button ID="btnDelete" runat="server" Text="Delete" />
				                    </td>
			                    </tr>
			                    </table>
                            </asp:PlaceHolder>
	                    </td>
	                    <td bgcolor="000000"><img src="../graphics/spacer.gif" width="1" alt="" /></td>
	                    <td width="25%" bgcolor="FFFFFF" valign="top">
                            <p class="subtitle">Edit Your Info</p>
		                    <a href="edit_org.aspx" title="Link to Edit Organization">Edit Organization Info</a><br><br>
		                    <a href="edit_account.aspx" title="Link to Edit Account">Edit Your Account</a><br><br>
		                    <a href="edit_password.aspx" title="Link to Edit Password">Change Password</a>	
	                    </td>
	                    <td bgcolor="000000"><img src="../graphics/spacer.gif" width="1" alt="" /></td>
	                    <td width="20%" bgcolor="FFFFFF" valign="top">
		                    <p class="subtitle"><a href="../faq_org.aspx" title="Link to Organization FAQs" tabindex="18">Posting/Editing FAQs</a></p>
		                    <p class="subtitle"><a href="../logout.aspx?type=org" title="Log Out" tabindex="19">Log Out</a></p>
		                    <br />
		                    <table width="95%" cellpadding="5" cellspacing="0" border="0" bgcolor="dbdbdb">
		                    <tr>
			                    <td><span class="subtitle">Let us know what you think!</span><br />
				                    <span class="text">We are interested in hearing from you. Fill out our 
				                    <a href="org_feedback.aspx" title="Go to Organization Feedback" tabindex="11">feedback form</a>.</span>
			                    </td>
		                    </tr>
		                    </table>
	                    </td>
                    </tr>
                    </table>    
                </div>
    
                <proj:Footer ID="footer" runat="server" />
            </div>
        </center>

    </form>
</body>
</html>
