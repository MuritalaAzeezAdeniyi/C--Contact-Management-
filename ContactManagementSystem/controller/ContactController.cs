using ContactManagementSyatem.dto;
using ContactManagementSyatem.dto.response;
using ContactManagementSyatem.service;
using System.Net;

namespace ContactManagementSyatem.controller;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]    

public class ContactController : ControllerBase
{
    private readonly IContactService _contact;
    public ContactController(IContactService contact)
    {
        _contact = contact;
    }

    [HttpPost("addContact")]
    public async Task<ActionResult<AddContactResponse>> addContact([FromBody] AddContactRequest request)
    {
        var createdContact = await _contact.AddContact(request);
        return Ok(createdContact);
    }

    [HttpDelete("delete")]
    public async Task<ActionResult<DelectUserResponse>> deleteContat([FromBody] FindUserRequest request)
    {
        var deleteContact = await _contact.DelectContact(request);
        return Ok(deleteContact);
    }
   
    [HttpPut("update/{userId}")]
    public async Task<ActionResult<UpdateContactResponse>> updateContact( string userId, [FromBody] 
        UpdateContactRequest request)
    {
        var updatedContact = await _contact.UpdateContact(userId, request);
        return Ok(updatedContact);
    }
     
}

