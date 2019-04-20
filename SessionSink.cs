using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
/// -----------------------------------------------------------------------------
/// Project	 : web
/// Class	 : SessionSink
/// 
/// -----------------------------------------------------------------------------
/// <summary>
/// 
///      Provides Strongly typed properties to maintain State across Postbacks
/// 
/// </summary>
/// <remarks>
/// </remarks>
/// <history>
/// 	[CWolfe0]	Winter/2006	Created
///     [CWolfe0]	9/29/2006	Modify        
///         save to the session object at creation.
///         Add new Method to update the Session object.
/// </history>
/// -----------------------------------------------------------------------------
public class SessionSink
{


    #region " Member Variables "



    private CBIZemployee m_currentUser;
    private RecognitionNews m_RecognitionNews;
    private NewsArticle m_NewsArticle;
    private MainArticle m_mainArticle;
    private Generic.List<NewsArticle> m_GOB_collection;
    private JobSubmittal m_JobSubmittal;
    private DataTable m_SomeDataTable;
    private TRACS.ServiceCodesData m_ServiceCodesData;
    private int m_recognitonCount;
    private DataSet m_grabBag;

    private DataTable m_overrides;


    #endregion

    #region " Public Properties "

    public DataTable MCOverrides
    {
        get { return this.m_overrides; }
        set { this.m_overrides = value; }
    }



    public DataSet GrabBag
    {
        get { return this.m_grabBag; }
        set { this.m_grabBag = value; }
    }

    public DataTable SomeDataTable
    {
        get { return this.m_SomeDataTable; }

        set
        {
            this.m_SomeDataTable = value;
            this.UpdateSessionObject();

        }
    }

    public CBIZemployee CurrentUser
    {
        get { return this.m_currentUser; }
        set
        {
            this.m_currentUser = value;
            this.UpdateSessionObject();
        }
    }

    public RecognitionNews CurrentNews
    {
        get { return this.m_RecognitionNews; }
        set
        {
            this.m_RecognitionNews = value;
            this.UpdateSessionObject();
        }
    }

    public NewsArticle CurrentArticle
    {
        get { return this.m_NewsArticle; }
        set
        {
            this.m_NewsArticle = value;
            this.UpdateSessionObject();
        }
    }

    public MainArticle RotatorAticle
    {
        get { return this.m_mainArticle; }

        set
        {
            this.m_mainArticle = value;
            this.UpdateSessionObject();

        }
    }

    public Generic.List<NewsArticle> GOB_Articles
    {
        get { return this.m_GOB_collection; }
        set
        {
            this.m_GOB_collection = value;
            this.UpdateSessionObject();
        }
    }


    public JobSubmittal RecruitingJob
    {
        get { return this.m_JobSubmittal; }

        set
        {
            this.m_JobSubmittal = value;
            this.UpdateSessionObject();

        }
    }

    public int RecognitionCount
    {
        get { return this.m_recognitonCount; }
        set
        {
            this.m_recognitonCount = value;
            this.UpdateSessionObject();
        }
    }

    public TRACS.ServiceCodesData ServiceCodesData
    {
        get { return this.m_ServiceCodesData; }
        set
        {
            this.m_ServiceCodesData = value;
            this.UpdateSessionObject();
        }
    }


    #endregion

    #region " Constructors "
    /// -----------------------------------------------------------------------------
    /// <summary>
    ///        Make the constructor handle Saving the Session object by having the setter
    ///        call the the UpdateSessionObject
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 	[CWolfe0]	9/29/2006	Modify
    ///         save to the session object at creation.
    /// </history>
    /// -----------------------------------------------------------------------------

    public SessionSink(CBIZemployee myUser)
    {
        this.CurrentUser = myUser;

    }

    #endregion

    #region " Methods "
    /// -----------------------------------------------------------------------------
    /// <summary>
    ///      Provide a method that UI code can call to handle Saving the 
    ///     Session Object
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <history>
    /// 	[CWolfe0]	9/29/2006	Modify
    ///         Add new Method to update the Session object.
    /// </history>
    /// -----------------------------------------------------------------------------

    public void UpdateSessionObject()
    {
        System.Web.HttpContext.Current.Session["AppSink"] = this;

    }





    #endregion

}

//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================

