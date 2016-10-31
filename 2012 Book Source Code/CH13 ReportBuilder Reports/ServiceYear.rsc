<?xml version="1.0" encoding="utf-8"?>
<ComponentItem xmlns:rdl="http://schemas.microsoft.com/sqlserver/reporting/2010/01/reportdefinition" xmlns:rd="http://schemas.microsoft.com/SQLServer/reporting/reportdesigner" Name="ServiceYear" xmlns="http://schemas.microsoft.com/sqlserver/reporting/2010/01/componentdefinition">
  <Properties>
    <Property Name="Type">ReportParameter</Property>
    <Property Name="ThumbnailSource">iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAACxEAAAsRAX9kX5EAAAP2SURBVEhLtVVNTFRXFD7vzQx/oUSoO8CMSEPSgFCRjAlIkxq0mYF2yqYxDYTVaOLCGTa12mAw8pNMYkC6gbogYIgklGnlCbSipO7K2CUQSogsVH4SYqp2eDC8uT3nvHenAxQNid5537vn3HvuOff8vVGEEPA+h1J5tuWdW/h94LIiL80GMg4eYl5RFFBtNlBVggp2ux3sjiTmFZsKySkpTNtwT0E52rchFAV5PEtj6kEIEg2o28MjDZNTlmOKYMrcMd87+TeF+L2HCJqvt2OehY4wEDFiLJrWdg0SYMTwTQ/PMZ4Jlj6g4iHIECWjm0TLGBGdjBJmPOTEvAlz2XrLtf+pyMQcrMuS5ZlTEC8GU3HiYF7mCakYAHqwKx1sABW+RvnU0N0RGP7lLvw8otHtogJi+MM3nmaXDQGGBVJmGBIGGCS5lwd4FE0L8H5RDd6aGviy2kPCDvOSphlSaJnDJSMeYzLO3tHt9wyRgIz/wrK771ROj5m0RCU27AWH3YG9QDB7otr9OQXFh8gjgkPEt2Ogo9J1pA0DsWXAlrGFPsoEx7ipCIuLi9DY2MhNScYIjYGLoGnax6i2BlEqc8C3w4KzFFHGZLWgQnaKQiVYMcm2tbVBbW0t5OfnQzQajaO+vh4aGhq+am1t/ShuQJaeNjoOI2NjiHEuwdHf7oM29ivzVFH4QcBPiR2GhoZgbm4O+vpvw8nKT8HvD4DD4YDu7m5IS0uDEydcj3t6ek6urKykcaNtbOgvEEKX0JHW9a2IHhGRCNM4R0hOLC8vi+LiYrGxuSE2NzfFteZm5peWlpgmV/1+/48tLS0/0GyFCA6g1y+pmDD0smrWkeAC5/q2cj8xMQF4mMM2PT0NTVevQm9vL3yYlQV5Rziv0NTU9KysrOyPtbW1VDstGFHUqkLG+P2JxEZJ39k1rrLj8HByEnznzvPWle+vgNvjhuTUVObD4cdQ8skxyMzMjB9lA1Tf9Jw+9dlOndv4pCQHfJCeDiVHi2Bd12H03ij09/dDntPJfGdnJ3x76Ts68zwcDrsqKipWd3yu36h/Wx8tLCywsMvlwsoC6OvrY76o6ChN+sDAQInH45m321Tbo+CNm5VUw28bZ06fgpevXsGINoYxP8DiT589h6mpMAwODoLTeRhycnJWCwsLfVVVVbPZ2dn/xFtefl7fMn/T1dV1h6oD5YIFBQVzaEMEg8FbVDVEE6z9+rq6utvKPv/0S1FBqdPpvNDR0THu9XrX9/I6FAr9PTs7e2S/Bkifb2Zm5qDb7f46Nzd3qb29/c/y8vJooqFAIJA9P/9Xlqbd691viEg+E+EjUCiwJJ/I0NDs8bh/Gh4eDuB+DeFfxHbSw67ZeJAAAAAASUVORK5CYII=</Property>
    <Property Name="ThumbnailMimeType">image/png</Property>
  </Properties>
  <RdlFragment>
    <rdl:Report>
      <rdl:AutoRefresh>0</rdl:AutoRefresh>
      <rdl:ReportSections>
        <rdl:ReportSection>
          <rdl:Body>
            <rdl:Height>0in</rdl:Height>
            <rdl:Style />
          </rdl:Body>
          <rdl:Width>0in</rdl:Width>
          <rdl:Page>
            <rdl:Style />
          </rdl:Page>
        </rdl:ReportSection>
      </rdl:ReportSections>
      <rdl:ReportParameters>
        <rdl:ReportParameter Name="ServiceYear">
          <rdl:DataType>String</rdl:DataType>
          <rdl:DefaultValue>
            <rdl:Values>
              <rdl:Value>2009</rdl:Value>
            </rdl:Values>
          </rdl:DefaultValue>
          <rdl:Prompt>Service Year</rdl:Prompt>
          <rdl:ValidValues>
            <rdl:ParameterValues>
              <rdl:ParameterValue>
                <rdl:Value>2009</rdl:Value>
              </rdl:ParameterValue>
              <rdl:ParameterValue>
                <rdl:Value>2010</rdl:Value>
              </rdl:ParameterValue>
              <rdl:ParameterValue>
                <rdl:Value>2011</rdl:Value>
              </rdl:ParameterValue>
            </rdl:ParameterValues>
          </rdl:ValidValues>
          <ComponentMetadata>
            <ComponentId>5e12fc1c-72b9-4e80-bf41-a0d7af45f8ef</ComponentId>
            <SourcePath>/Report Parts/ServiceYear</SourcePath>
            <SyncDate>2012-06-18T22:10:55.8017578-04:00</SyncDate>
          </ComponentMetadata>
        </rdl:ReportParameter>
      </rdl:ReportParameters>
      <rd:ReportUnitType>Invalid</rd:ReportUnitType>
      <rd:ReportID>004d92a2-8015-4eb1-9be5-13b0b964f139</rd:ReportID>
    </rdl:Report>
  </RdlFragment>
</ComponentItem>